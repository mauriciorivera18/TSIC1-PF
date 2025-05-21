using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PuzzleUIManager : MonoBehaviour
{
    public GameObject instructionsBox;
    public GameObject winPanel;
    public Button continueButton;

    public AudioSource musicSource;
    public AudioClip levelClip;
    public AudioClip winClip;

    void Start()
    {
        musicSource.clip = levelClip;
        musicSource.Play();
        continueButton.onClick.AddListener(OnContinueButtonPressed);
        HideWinPanel();
    }

    public void ShowWinPanel()
    {
        musicSource.clip = winClip;
        musicSource.Play();
        if (winPanel != null)
            winPanel.SetActive(true);
        if (instructionsBox != null)
            instructionsBox.SetActive(false);
    }

    public void HideWinPanel()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    void OnContinueButtonPressed()
    {
        SceneManager.LoadScene("V8");
    }
}
