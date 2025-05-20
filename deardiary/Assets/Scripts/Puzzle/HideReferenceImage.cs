using UnityEngine;

public class HideReferenceImage : MonoBehaviour
{
    public float hideDelay = 5f;
    private bool firstMoveDetected = false;
    private bool alreadyHidden = false;

    void Start()
    {
        Invoke("HideAfterDelay", hideDelay);
    }

    public void OnFirstPieceMoved()
    {
        if (!alreadyHidden)
        {
            firstMoveDetected = true;
            HideImage();
        }
    }

    private void HideAfterDelay()
    {
        if (!firstMoveDetected && !alreadyHidden)
        {
            HideImage();
        }
    }

    private void HideImage()
    {
        gameObject.SetActive(false);
        alreadyHidden = true;
    }
}
