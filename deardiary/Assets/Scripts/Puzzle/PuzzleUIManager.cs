using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PuzzleUIManager : MonoBehaviour
{
    public GameObject instructionsBox;
    public GameObject winPanel;
    public Button continueButton;

    private ShuffleGameManager gameManager;

    void Start()
    {
        continueButton.onClick.AddListener(OnContinueButtonPressed);
        HideWinPanel();
    }

    /// <summary>
    /// Muestra el panel de Victoria.
    /// </summary>
    public void ShowWinPanel()
    {
        if (winPanel != null)
            winPanel.SetActive(true);
        if (instructionsBox != null)
            instructionsBox.SetActive(false);
        Debug.Log("UIManagerAR: Mostrando pantalla de Victoria.");
    }

    /// <summary>
    /// Oculta el panel de Victoria.
    /// </summary>
    public void HideWinPanel()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
        Debug.Log("UIManagerAR: Ocultando pantalla de Victoria.");
    }

    void OnContinueButtonPressed()
    {
        // Puedes cambiar "NombreDeLaSiguienteEscena" por la escena que desees cargar.
        Debug.Log("UIManagerAR: Botón Continuar presionado.");
        SceneManager.LoadScene("V8");
    }
}
