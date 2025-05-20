using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour
{
    public Transform targetSlot;
    public float snapDistance = 0.5f;
    private bool placed = false;
    private Vector3 originalScale;
    private Renderer rend;
    private Color originalColor;
    private bool isDragging = false;
    private Plane dragPlane;

    void Start()
    {
        originalScale = transform.localScale;
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void Update()
    {
        transform.localScale = originalScale;

        // --- Soporte para Mouse (Editor o PC) ---
        if (!placed && Input.GetMouseButtonDown(0))
        {
            TryStartDrag(Input.mousePosition);
        }
        if (isDragging && !placed && Input.GetMouseButton(0))
        {
            Drag(Input.mousePosition);
        }
        if (isDragging && Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }

        // --- Soporte para Touch (Móviles) ---
        if (!placed && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = touch.position;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    TryStartDrag(touchPos);
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (isDragging)
                        Drag(touchPos);
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (isDragging)
                        EndDrag();
                    break;
            }
        }
    }

    void TryStartDrag(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            isDragging = true;
            dragPlane = new Plane(-Camera.main.transform.forward, transform.position);
            Debug.Log($"{gameObject.name} drag iniciado");
        }
    }

    void Drag(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        if (dragPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            transform.position = hitPoint;
        }
    }

    void EndDrag()
    {
        isDragging = false;
        if (!placed && Vector3.Distance(transform.position, targetSlot.position) < snapDistance)
        {
            transform.position = targetSlot.position;
            placed = true;
            StartCoroutine(SnapEffect());
            rend.material.EnableKeyword("_EMISSION");
            rend.material.SetColor("_EmissionColor", Color.green);
            Debug.Log($"{gameObject.name} POSICIONADA correctamente en {targetSlot.name}");
            PuzzleManager.Instance.PiecePlacedCorrectly();
        }
        else if (!placed)
        {
            Debug.Log($"{gameObject.name} NO está cerca de la posición correcta ({targetSlot.name})");
        }
    }

    IEnumerator SnapEffect()
    {
        Vector3 popped = originalScale * 1.15f;
        transform.localScale = popped;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = originalScale;
    }
}
