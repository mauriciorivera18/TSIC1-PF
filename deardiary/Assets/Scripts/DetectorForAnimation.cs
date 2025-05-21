using UnityEngine;
using Vuforia;

public class DetectorForAnimation : MonoBehaviour
{
    public ObserverBehaviour[] ImageTargets; // Arreglo de marcadores
    public GameObject objetoAActivar;        // Objeto que se activa/desactiva

    private int currentTarget = -1;

    void OnEnable()
    {
        foreach (var target in ImageTargets)
        {
            if (target != null)
                target.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    void OnDisable()
    {
        foreach (var target in ImageTargets)
        {
            if (target != null)
                target.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    /*
    * Se llama cuando el estado de un marcador de Vuforia cambia.
    *
    * Args:
    *   behaviour: El ObserverBehaviour correspondiente al marcador detectado.
    *   status: El estado del marcador (TRACKED, NOT_FOUND, ...).
    */
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        int index = System.Array.IndexOf(ImageTargets, behaviour);

        if (status.Status == Status.TRACKED && index != -1)
        {
            currentTarget = index;
            if (objetoAActivar != null)
                objetoAActivar.SetActive(true);
        }
        else if (index == currentTarget && status.Status != Status.TRACKED)
        {
            currentTarget = -1;
            if (objetoAActivar != null)
                objetoAActivar.SetActive(false);
        }
    }
}
