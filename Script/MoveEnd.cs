using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveEnd : MonoBehaviour
{
    public float Speed;
    public GameObject End;

    void Start()
    {
        End.SetActive(false);  
        StartCoroutine("Inicio");
    }
    void Update()
    {
        Move();
        
    }
    public void Move()
    {
        transform.Translate(new Vector3(0,0.03f,0 * Speed * Time.deltaTime));  
    }
    IEnumerator Inicio()
    {
        yield return new WaitForSeconds(7);
        End.SetActive(true);
    }
}
