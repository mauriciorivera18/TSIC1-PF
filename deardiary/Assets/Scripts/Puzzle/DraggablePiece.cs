using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePiece : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 offset;
    private Vector3 startPos;
    private CanvasGroup canvasGroup;

    public Vector3 correctPosition;
    public float snapThreshold = 0.1f;
    public GameObject indicator;

    private static bool hasMovedFirstPiece = false;
    private HideReferenceImage referenceImage;

    void Awake()
    {
        startPos = transform.localPosition;
        canvasGroup = GetComponent<CanvasGroup>();
        referenceImage = FindObjectOfType<HideReferenceImage>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            offset = transform.position - hit.point;
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;

        if (!hasMovedFirstPiece)
        {
            hasMovedFirstPiece = true;
            if (referenceImage != null)
                referenceImage.OnFirstPieceMoved();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit hit;

        // Plane where puzzle pieces are placed (e.g., Y = 0 on ImageTarget)
        Plane dragPlane = new Plane(Vector3.up, Vector3.zero);

        float distance;
        if (dragPlane.Raycast(ray, out distance))
        {
            Vector3 worldPoint = ray.GetPoint(distance);
            transform.position = worldPoint + offset;
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        float distance = Vector3.Distance(transform.localPosition, correctPosition);
        if (distance <= snapThreshold)
        {
            transform.localPosition = correctPosition;
            if (indicator != null) indicator.SetActive(true);
        }
        else
        {
            if (indicator != null) indicator.SetActive(false);
        }
    }

    public bool IsInCorrectPosition()
    {
        return Vector3.Distance(transform.localPosition, correctPosition) <= snapThreshold;
    }
}
