using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using static UnityEngine.GraphicsBuffer;
using Image = UnityEngine.UI.Image;

public class TextBoxMangment : MonoBehaviour
{
    public int currentTarget;
    public float speed = 1.0f;
    public int noTarget = 0;
    public AudioSource audioSource;
    public AudioClip[] clips;

    private const float DIR_THRESHOLD = 0.8f;
    private Vector2 startingPosition;

    //Estados
    Transform textBoxItem;
    //public bool[] itemFound;

    //Texto
    public GameObject textBox;

    //Importar todos los iconos
    public GameObject[] icons;


    public TMP_Text textTemplate;
    public TMP_Text erasedTextTemplate;
    public TMP_Text creepyTextTemplate;
    public TMP_Text[] textComponent;
    public float delay = 0.05f;
    private string fullText;
    private string optionTemplate;
    private bool stopTextCoroutine = false;
    public Image tempColor;
    public Image tempIcon;

    //Gestos
    List<int> availableTargets = new List<int>();

    //Start is called before the first frame update
    void Start()
    {
        textBoxItem = GameObject.Find("TextBox").transform;
        textTemplate.text = "";
        textBox.SetActive(false);
        erasedTextTemplate.text = "";
        foreach (GameObject icon in icons)
        {
            icon.SetActive(false);
        }
        foreach (TMP_Text text in textComponent)
        {
            text.gameObject.SetActive(false);
        }
        print(textBoxItem.Find("01")?.GetComponent<TMP_Text>().text);
        StartCoroutine(ShowText(noTarget));
    }

    //Corrutina que muestra cuadros de texto e indica si el flujo
    //del juego es el correcto
    private IEnumerator ShowText(int noTarget)
    {
        stopTextCoroutine = false;
        yield return new WaitForSeconds(1.0f);
        int tmp = 0;
        switch (noTarget)
        {
            case 0:
                audioSource.clip = clips[0];
                audioSource.Play();
                textBox.SetActive(true);
                textTemplate.text = "";
                yield return new WaitForSeconds(0.5f);

                audioSource.clip = clips[1];
                fullText = textBoxItem.Find("01")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);


                icons[0].SetActive(true);
                fullText = textBoxItem.Find("02")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                audioSource.clip = clips[2];
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                fullText = textBoxItem.Find("03")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                fullText = textBoxItem.Find("04")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);


                fullText = textBoxItem.Find("05")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[0].SetActive(false);
                icons[4].SetActive(true);
                fullText = textBoxItem.Find("06")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[4].SetActive(false);
                icons[0].SetActive(true);
                fullText = textBoxItem.Find("07")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[0].SetActive(false);
                icons[4].SetActive(true);
                fullText = textBoxItem.Find("08")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[4].SetActive(false);
                icons[0].SetActive(true);
                fullText = textBoxItem.Find("09")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);


                fullText = textBoxItem.Find("10")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                fullText = textBoxItem.Find("11")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay/0.9f);
                }
                yield return new WaitForSeconds(1.0f);
                audioSource.clip = clips[0];
                audioSource.Play();
                textBox.SetActive(false);
                icons[0].SetActive(false);
                textTemplate.text = "";
                break;

            case 1:
                audioSource.clip = clips[0];
                audioSource.Play();
                textBox.SetActive(true);
                textTemplate.text = "";
                yield return new WaitForSeconds(0.5f);

                audioSource.clip = clips[1];
                fullText = textBoxItem.Find("2_01")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);


                icons[9].SetActive(true);
                fullText = textBoxItem.Find("2_02")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                audioSource.clip = clips[2];
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[9].SetActive(false);
                icons[2].SetActive(true);
                fullText = textBoxItem.Find("2_03")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[2].SetActive(false);
                icons[4].SetActive(true);
                fullText = textBoxItem.Find("2_04")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[4].SetActive(false);
                icons[0].SetActive(true);
                fullText = textBoxItem.Find("2_05")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                fullText = textBoxItem.Find("2_06")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);

                }
                yield return new WaitForSeconds(1.0f);

                icons[0].SetActive(false);
                icons[9].SetActive(true);
                fullText = textBoxItem.Find("2_07")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                tempColor = textBox.GetComponent<Image>();
                tempColor.color = new Color(0.5f, 0.5f, 0.5f);
                tempIcon = icons[9].GetComponent<Image>();
                tempIcon.color = new Color(0.5f, 0.5f, 0.5f);
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    //audioSource.Play();
                    yield return new WaitForSeconds(delay*1.8f);
                }
                textTemplate.text = "";
                var full2 = "DEBESCONTINUARCONTINUAJUGANDO";
                audioSource.clip = clips[3];
                foreach (char letter in full2)
                {
                    if (stopTextCoroutine)
                        yield break;
                    erasedTextTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay/3.0f);
                }
                icons[9].SetActive(false);
                tempColor.color = new Color(1.0f, 1.0f, 1.0f);
                tempIcon.color = new Color(1.0f, 1.0f, 1.0f);
                yield return new WaitForSeconds(0.3f);
                icons[12].SetActive(true);
                yield return new WaitForSeconds(0.25f);
                icons[12].SetActive(false);
                yield return new WaitForSeconds(0.5f);
                icons[4].SetActive(true);
                erasedTextTemplate.text = "";
                audioSource.clip = clips[2];
                fullText = textBoxItem.Find("2_08")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                
                yield return new WaitForSeconds(1.0f);
                audioSource.clip = clips[0];
                audioSource.Play();
                textBox.SetActive(false);
                icons[4].SetActive(false);
                textTemplate.text = "";
                break;

            case 2:
                audioSource.clip = clips[0];
                audioSource.Play();
                textBox.SetActive(true);
                textTemplate.text = "";
                yield return new WaitForSeconds(0.5f);

                audioSource.clip = clips[1];
                fullText = textBoxItem.Find("3_01")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[8].SetActive(true);
                fullText = textBoxItem.Find("3_02")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                audioSource.clip = clips[2];
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                fullText = textBoxItem.Find("3_03")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[8].SetActive(false);
                icons[2].SetActive(true);
                fullText = textBoxItem.Find("3_04")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[2].SetActive(false);
                icons[8].SetActive(true);
                fullText = textBoxItem.Find("3_05")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                fullText = textBoxItem.Find("3_06")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[8].SetActive(false);
                icons[6].SetActive(true);
                fullText = textBoxItem.Find("3_07")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                icons[6].SetActive(false);
                icons[8].SetActive(true);
                fullText = textBoxItem.Find("3_08")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);
                tempColor = textBox.GetComponent<Image>();
                tempColor.color = new Color(0.75f, 0.75f, 0.75f);
                tempIcon = icons[8].GetComponent<Image>();
                tempIcon.color = new Color(0.75f, 0.75f, 0.75f);
                fullText = textBoxItem.Find("3_09")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay*1.5f);
                }
                yield return new WaitForSeconds(1.0f);

                tempColor.color = new Color(0.50f, 0.50f, 0.50f);
                //tempIcon = icons[8].GetComponent<Image>();
                tempIcon.color = new Color(0.50f, 0.50f, 0.50f);
                fullText = textBoxItem.Find("3_10")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay*1.5f);
                }
                yield return new WaitForSeconds(1.0f);

                icons[8].SetActive(false);
                icons[7].SetActive(true);
                tempColor.color = new Color(0.25f, 0.25f, 0.25f);
                tempIcon = icons[7].GetComponent<Image>();
                tempIcon.color = new Color(0.25f, 0.25f, 0.25f);
                fullText = textBoxItem.Find("3_11")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay*1.5f);
                }
                textTemplate.text = "";
       
                tempColor.color = new Color(0.25f, 0.0f, 0.0f);
                tempIcon.color = new Color(0.25f, 0.0f, 0.0f);
                tempIcon = icons[10].GetComponent<Image>();
                tempIcon.color = new Color(0.25f, 0.0f, 0.0f);
                fullText = textBoxItem.Find("3_12")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    //audioSource.Play();
                    yield return new WaitForSeconds(delay/1.5f);
                }
                full2 = "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■" +
    "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■" +
    "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■" +
    "■■■■■■■■■■■■■■■";
                audioSource.clip = clips[3];
                foreach (char letter in full2)
                {
                    if (stopTextCoroutine)
                        yield break;
                    erasedTextTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay / 50.0f);
                }
                yield return new WaitForSeconds(1.0f);

                icons[7].SetActive(false);
                tempIcon = icons[7].GetComponent<Image>();
                tempColor.color = new Color(1.0f, 1.0f, 1.0f);

                erasedTextTemplate.text = "";
                fullText = textBoxItem.Find("3_13")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    //audioSource.Play();
                    icons[10].SetActive(true);
                    yield return new WaitForSeconds(delay);
                    icons[10].SetActive(false);
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);
                foreach (char letter in full2)
                {
                    if (stopTextCoroutine)
                        yield break;
                    erasedTextTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay / 50.0f);
                }

                yield return new WaitForSeconds(0.5f);
                tempIcon = icons[14].GetComponent<Image>();
                tempIcon.color = new Color(0.25f, 0.0f, 0.0f);
                icons[14].SetActive(true);
                yield return new WaitForSeconds(0.5f);
                icons[14].SetActive(false);
                yield return new WaitForSeconds(3.0f);
                erasedTextTemplate.text = "";
                icons[3].SetActive(true);

                tempColor.color = new Color(1.0f, 1.0f, 1.0f);
                tempIcon.color = new Color(1.0f, 1.0f, 1.0f);

                fullText = textBoxItem.Find("3_14")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    //audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                fullText = textBoxItem.Find("3_15")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    //audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                fullText = textBoxItem.Find("3_16")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    //audioSource.Play();
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitForSeconds(1.0f);

                audioSource.clip = clips[0];
                audioSource.Play();
                textBox.SetActive(false);
                icons[3].SetActive(false);
                textTemplate.text = "";
                break;
            case 3:
                audioSource.clip = clips[0];
                audioSource.Play();
                yield return new WaitForSeconds(0.5f);
                tempIcon = icons[7].GetComponent<Image>();
                tempIcon.color = new Color(0.5f, 0.5f, 0.5f);
                tempIcon = icons[3].GetComponent<Image>();
                tempIcon.color = new Color(1.0f, 0.0f, 0.0f);
                tempIcon = icons[1].GetComponent<Image>();
                tempIcon.color = new Color(1.0f, 0.0f, 0.0f);
                tempColor = textBox.GetComponent<Image>();
                tempColor.color = new Color(0.5f, 0.5f, 0.5f);
                icons[7].SetActive(true);
                textBox.SetActive(true);
                textTemplate.text = "";
                audioSource.clip = clips[2];
                fullText = textBoxItem.Find("4_01")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay/1.5f);
                }
                TextShakeEffect a = textTemplate.GetComponent<TextShakeEffect>();
                a.enabled = true;
                full2 = "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■" +
"■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■" +
"■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■" +
"■■■■■■■■■■■■■■■";
                audioSource.clip = clips[3];
                foreach (char letter in full2)
                {
                    if (stopTextCoroutine)
                        yield break;
                    erasedTextTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay / 50.0f);
                }
                yield return new WaitForSeconds(1.0f);
                erasedTextTemplate.text = "";
                a.enabled=false;

                tempColor.color = new Color(1.0f, 0.0f, 0.0f);
                icons[7].SetActive(false);
                icons[3].SetActive(true);
                fullText = textBoxItem.Find("4_02")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    creepyTextTemplate.text += letter;
                    //audioSource.Play();
                    yield return new WaitForSeconds(delay*2.0f);
                }
                yield return new WaitForSeconds(1.0f);

                tempColor.color = new Color(0.5f, 0.5f, 0.5f);
                icons[7].SetActive(true);
                icons[3].SetActive(false);
                fullText = textBoxItem.Find("4_03")?.GetComponent<TMP_Text>().text;
                creepyTextTemplate.text = "";
                audioSource.clip = clips[2];
                
                
                foreach (char letter in fullText)
                {
                    
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay/1.5f);
                }
                a.enabled = true;
                yield return new WaitForSeconds(0.5f);
                a.enabled = false;
                full2 = "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■" +
"■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■" +
"■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■" +
"■■■■■■■■■■■■■■■";
                audioSource.clip = clips[3];
                foreach (char letter in full2)
                {
                    if (stopTextCoroutine)
                        yield break;
                    erasedTextTemplate.text += letter;
                    audioSource.Play();
                    yield return new WaitForSeconds(delay / 50.0f);
                }
                yield return new WaitForSeconds(1.0f);
                erasedTextTemplate.text = "";

                tempColor.color = new Color(1.0f, 0.0f, 0.0f);
                icons[7].SetActive(false);
                icons[1].SetActive(true);
                fullText = textBoxItem.Find("4_04")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    creepyTextTemplate.text += letter;
                    //audioSource.Play();
                    yield return new WaitForSeconds(0.15f);
                }
                yield return new WaitForSeconds(1.0f);
                audioSource.clip = clips[0];
                audioSource.Play();
                textBox.SetActive(false);
                icons[1].SetActive(false);
                creepyTextTemplate.text = "";
                break;
            case 4:
                icons[5].SetActive(true);
                tempColor = textBox.GetComponent<Image>();
                tempColor.color = new Color(0.0f, 0.0f, 0.0f);
                textBox.SetActive(true);
                yield return new WaitForSeconds(2.0f);

                creepyTextTemplate.text = "";
                creepyTextTemplate.color = new Color(1.0f, 1.0f, 1.0f);
                audioSource.clip = clips[4];
                fullText = textBoxItem.Find("5_01")?.GetComponent<TMP_Text>().text;

                
                audioSource.Play();
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    creepyTextTemplate.text += letter;
                    yield return new WaitForSeconds(0.14f);
                }
                yield return new WaitForSeconds(0.15f);
                fullText = textBoxItem.Find("5_02")?.GetComponent<TMP_Text>().text;
                creepyTextTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    creepyTextTemplate.text += letter;
                    yield return new WaitForSeconds(0.13f);
                }
                icons[5].SetActive(false);
                icons[11].SetActive(true);
                fullText = textBoxItem.Find("5_03")?.GetComponent<TMP_Text>().text;
                creepyTextTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    creepyTextTemplate.text += letter;
                    yield return new WaitForSeconds(0.12f);
                }
                fullText = textBoxItem.Find("5_04")?.GetComponent<TMP_Text>().text;
                creepyTextTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    creepyTextTemplate.text += letter;
                    yield return new WaitForSeconds(0.12f);
                }
                audioSource.clip = clips[5];
                textBox.SetActive(true);
                fullText = textBoxItem.Find("5_05")?.GetComponent<TMP_Text>().text;
                creepyTextTemplate.text = "";
                audioSource.Play();
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    creepyTextTemplate.text += letter;
                    yield return new WaitForSeconds(0.13f);
                }
                fullText = textBoxItem.Find("5_06")?.GetComponent<TMP_Text>().text;
                creepyTextTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    creepyTextTemplate.text += letter;
                    yield return new WaitForSeconds(0.14f);
                }
                fullText = textBoxItem.Find("5_07")?.GetComponent<TMP_Text>().text;
                creepyTextTemplate.text = "";
                foreach (char letter in fullText)
                {
                    icons[13].SetActive(true);
                    if (stopTextCoroutine)
                        yield break;
                    creepyTextTemplate.text += letter;
                    yield return new WaitForSeconds(0.07f);
                    icons[13].SetActive(false);
                    yield return new WaitForSeconds(0.07f);
                }
                icons[11].SetActive(false);
                icons[13].SetActive(true);
                yield return new WaitForSeconds(1.0f);
                textBox.SetActive(false);
                icons[13].SetActive(false);
                creepyTextTemplate.text = "";
                break;
            default:
                fullText = textBoxItem.Find("Bug")?.GetComponent<TMP_Text>().text;
                textTemplate.text = "";
                foreach (char letter in fullText)
                {
                    if (stopTextCoroutine)
                        yield break;
                    textTemplate.text += letter;
                    yield return new WaitForSeconds(delay);
                }
                textBox.SetActive(false);
                icons[0].SetActive(false);
                textTemplate.text = "";
                tempColor.color = new Color(1.0f, 1.0f, 1.0f);
                break;
        }
        //yield return new WaitForSeconds(1.0f);
        //textBox.SetActive(false);
        //textTemplate.text = "";
    }

    //// Update is called once per frame
    void Update()
    {

    }
}