using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeShield : MonoBehaviour
{
    private  Player Player;
    private Renderer rend;
    public float Timee = 0;
    void Start()
    {
        rend = GetComponent<Renderer>();
        Player = FindObjectOfType(typeof(Player)) as Player;
    }

    void Update()
    {
        if(Player.Shield == true)
        {
            StartCoroutine("FadeS");
        }
    }
    public IEnumerator FadeS()
    {
        
        for(float f =0; f<=1; f+=0.01f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return null;
        }
        
        Timee += Time.deltaTime;
        if(Timee >= 4)
        {
            
            for(float f =1; f>=0; f-=0.01f)
            {
                Timee = 0;
                Color c = rend.material.color;
                c.a = f;
                rend.material.color = c;
                yield return null;
            }  
        }
        
    }
}
