using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fade : MonoBehaviour
{
    private Renderer rend; 
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine("FadeOut");
    }

    public IEnumerator FadeIn()
    {
        for(float f =0; f<=1; f+=0.01f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return null;
        }
    }
    public IEnumerator FadeOut()
    {
        for(float f =1; f>=0; f-=0.01f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return null;
        }

    }
}
