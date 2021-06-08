using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    private _GC _GC;
    private int Gain = 10;

    void Start()
    {
        _GC = FindObjectOfType(typeof(_GC)) as _GC;
    }
    void OnBecameInvisible()
    {
        if(gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
        if(gameObject.tag == "asteroid")
        {
            Destroy(this.gameObject);
            _GC.score += 10;
        }
        if(gameObject.tag == "Laser")
        {
            Destroy(this.gameObject);
        }
        if(gameObject.tag == "EnemyLaser")
        {
            Destroy(this.gameObject);
        }
        if(gameObject.tag == "Explode")
        {
            Destroy(this.gameObject);
        }
    }
}
