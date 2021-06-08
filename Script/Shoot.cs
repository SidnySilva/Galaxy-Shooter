using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform Spawn;
    public GameObject bullet;
    public float FireSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Prefab = Instantiate(bullet) as GameObject;
            Prefab.transform.position = transform.position;
            Prefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,FireSpeed));
            Sounds.playSound(sound.Shoot);
        }
    }
}
