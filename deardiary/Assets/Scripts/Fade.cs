using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fade : MonoBehaviour
{
    public static Fade Instance;

    public Image fadeImage;                // Imagen negra para el fade de pantalla
    public CanvasGroup uiCanvasGroup;      // UI que queremos desvanecer
    //public string sceneName;
    public float fadeDuration = 1f;
    public AudioSource effect;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
        effect.Stop();
    }

    private void Start()
    {
        Color c = fadeImage.color;
        c.a = 1f;
        fadeImage.color = c;

        StartCoroutine(FadeIn());
        //new WaitForSeconds(5f);
        //StartCoroutine(WaitThenFadeOut(sceneName));
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeIn());
    }

    public void ChangeScene(string sceneName)
    {
        //StartCoroutine(FadeOut(sceneName));
        effect.Play();
        Debug.Log("Cambiando a la escena: " + sceneName);
        StartCoroutine(WaitThenFadeOut(sceneName));
    }

    IEnumerator WaitThenFadeOut(string sceneName)
    {
        // Espera 5 segundos antes de comenzar el fade out
        //yield return new WaitForSeconds(5f);

        // Ahora hace el fade y cambia de escena        
        yield return StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        Debug.Log("Fade In");
        //float t = fadeDuration;
        float t = 0;

        while (t > 0f)
        {
            //t -= Time.deltaTime;
            t += Time.deltaTime;
            float alpha = t / fadeDuration;

            if (fadeImage != null)
            {
                Color c = fadeImage.color;
                c.a = alpha;
                fadeImage.color = c;
            }

            if (uiCanvasGroup != null)
                uiCanvasGroup.alpha = alpha;

            yield return null;
        }

        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            //c.a = 0f;
            c.a = 1f;
            fadeImage.color = c;
        }

        if (uiCanvasGroup != null)
            uiCanvasGroup.alpha = 1f;
            //uiCanvasGroup.alpha = 0f;

    }

    IEnumerator FadeOut(string sceneName)
    {
        Debug.Log("Fade Out");
        float t = 0f;        

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            //float alpha = t / fadeDuration;
            float alpha = 1 - (t / fadeDuration);

            if (fadeImage != null)
            {
                Color c = fadeImage.color;
                c.a = alpha;
                fadeImage.color = c;
            }

            if (uiCanvasGroup != null)
                uiCanvasGroup.alpha = alpha;

            yield return null;
        }

        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }

        if (uiCanvasGroup != null)
            uiCanvasGroup.alpha = 0f;

        SceneManager.LoadScene(sceneName);
    }
}
