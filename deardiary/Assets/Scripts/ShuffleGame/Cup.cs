using UnityEngine;

//Comportamiento de los vasos en el juego
public class Cup : MonoBehaviour
{
    private ShuffleGameManager gameManager;
    private Vector3 initialPosition;
    private bool isLifted = false; //Si se ha levantado el vaso

    //Animaci�n del vaso
    private float raiseHeight = 0.15f;
    private float animationDuration = 0.7f;

    //Posici�n inicial
    private Vector3 initialLocalPosition;

    public void Setup(ShuffleGameManager manager)
    {
        gameManager = manager;
        initialLocalPosition = transform.localPosition;
        isLifted = false;
        transform.localPosition = initialLocalPosition;
    }

    // Inicia la animaci�n de levantamiento del vaso si se ha seleccionado
    public void AnimateLift()
    {
        if (!isLifted)
            StartCoroutine(RaiseCup());
    }

    //Ejecuta la animaci�n de levantar el vaso
    private System.Collections.IEnumerator RaiseCup()
    {
        isLifted = true;
        Vector3 targetPos = initialPosition + Vector3.up * raiseHeight;
        float elapsed = 0f;

        while (elapsed < animationDuration)
        {
            transform.localPosition = Vector3.Lerp(initialLocalPosition, targetPos, elapsed / animationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = targetPos;
    }

    // Regresa el vaso a su posici�n inicial para reiniciar el juego
    public void ResetCup()
    {
        StopAllCoroutines();
        transform.localPosition = initialPosition;
        isLifted = false;
    }
}