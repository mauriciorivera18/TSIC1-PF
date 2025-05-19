using UnityEngine;

public class ExpansionSangre : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(5f, 5f, 1f);
    public float speed = 0.1f;

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed);
    }


}
