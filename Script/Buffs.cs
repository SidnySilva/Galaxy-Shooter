using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{   
    private  Player Player;
    public float speed;
    public GameObject Speed, Triple, Shield;
    public GameObject Container;
    public bool Sp, T, Sh;
    public bool _StopSpawning = false;
    public int Sort;


    void Start()
    {
        StartCoroutine(SpawnRoutine());
        Player = FindObjectOfType(typeof(Player)) as Player;
        Sp = false;
        T = false;
        Sh= false;
    }

    public IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(2);
        while(!_StopSpawning)
        {
            Sort = Random.Range(1, 6);
            Sh = false;
            T = false;
            Sp = false;
            if(Sort == 1)
            {
                Sh = true;
                if(Sh == true)
                { 
                    Vector3 pos = new Vector3(Random.Range(-8.30f,8.30f),6 ,0);
                    GameObject G = Instantiate(Shield, pos, Quaternion.identity);
                    G.transform.parent = Container.transform;
                }
            } 
            else if(Sort == 2)
            {
                T = true;
                if(T == true)
                {
                    Vector3 pos = new Vector3(Random.Range(-8.30f,8.30f),6 ,0);
                    GameObject G = Instantiate(Triple, pos, Quaternion.identity);
                    G.transform.parent = Container.transform;

                }
                
            }
            else if(Sort == 3)
            {
                Sp = true;
                if(Sp == true)
                {
                    Vector3 pos = new Vector3(Random.Range(-8.30f,8.30f),6 ,0);
                    GameObject G = Instantiate(Speed, pos, Quaternion.identity);
                    G.transform.parent = Container.transform;
                }
            }
            
        yield return new WaitForSeconds(8);
        }
    }
    void OnPlayerDeath()
    {
        if(Player.Live == false)
        {
            _StopSpawning = true;
        }
    }
    
    

    
}
