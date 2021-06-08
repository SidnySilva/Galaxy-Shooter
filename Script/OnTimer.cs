using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTimer : MonoBehaviour
{
    public float Lifetime;
    private float temptime;
       void Start()
    {
        
    }

   
    void Update()
    {
        temptime = Time.deltaTime;
        if(temptime>=Lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
