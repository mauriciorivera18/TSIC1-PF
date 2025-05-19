using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BloodDissolve : MonoBehaviour
{
    public float dissolveSpeed;

    void Update()
    {
        Material blood = GetComponent<Renderer>().material;
        float start = blood.GetFloat("_DissolveStrength");
        blood.SetFloat("_DissolveStrength", Mathf.Lerp(start, 0.5f, Time.deltaTime*dissolveSpeed));

        if(blood.GetFloat("_DissolveStrength")== 0.0f)
        {
            
        }
    }



}

