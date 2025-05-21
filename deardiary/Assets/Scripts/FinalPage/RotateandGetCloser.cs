using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RotateandGetCloser : MonoBehaviour
{
    public Transform cameraTransform; // Asignar desde el Inspector o con Camera.main
    public float moveSpeed = 2f;
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clipend;
    public GameObject endScreen;
    public Button continueButton;

    private bool mover = false;
    private bool yaRotado = false;

    public void StartMovement()
    {
        mover = true;
        continueButton.onClick.AddListener(OnContinueButtonPressed);
    }

    void Update()
    {
        if (!mover || cameraTransform == null) return;

        audioSource.clip = clip;

        // Rotar 180° solo una vez
        if (!yaRotado)
        {
            audioSource.Play();
            transform.Rotate(0f, 180f, 0f); // Eje Y
            yaRotado = true;
        }

        // Mover hacia la cámara
        transform.position = Vector3.MoveTowards(
            transform.position,
            cameraTransform.position,
            moveSpeed * Time.deltaTime
            
        );
        if (yaRotado)
        {
            StartCoroutine(End());
        }
    }

    private System.Collections.IEnumerator End()
    {
        yield return new WaitForSeconds(15f);

        audioSource.clip = clipend;
        audioSource.Play();
        if (endScreen != null)
            endScreen.SetActive(true);
    }

    void OnContinueButtonPressed()
    {
        // Puedes cambiar "NombreDeLaSiguienteEscena" por la escena que desees cargar.
        Debug.Log("UIManagerAR: Botón Continuar presionado.");
        SceneManager.LoadScene("V3");
    }
}
