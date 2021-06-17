using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBuff : MonoBehaviour
{
    public GameObject Shield, Speed, Shot;
    public GameObject container;
    public int sort;
    private bool StopSpawning;
    public bool Sh, T, Sp;

    void Start()
    {
        StartCoroutine(BuffGo());
        Sp = false;
        T = false;
        Sh= false;
    }
    IEnumerator BuffGo()
    {
        while(!StopSpawning)
        {
            yield return new WaitForSeconds(0.5f);
            sort = Random.Range(1, 4);
            Sh = false;
            T = false;
            Sp = false;
            if(sort == 1)
            {
                Sh = true;
                if(Sh == true)
                {
                    Vector3 pos = new Vector3(Random.Range(-5.8f, 5.8f),-5,0); 
                    GameObject G = Instantiate(Shield, pos, Quaternion.identity); 
                    G.transform.parent = container.transform;
                    yield return new WaitForSeconds(13);
                }
            } 
            else if(sort == 2)
            {
                T = true;
                if(T == true)
                {
                    Vector3 pos = new Vector3(Random.Range(-5.8f, 5.8f),-5,0); 
                    GameObject G = Instantiate(Shot, pos, Quaternion.identity);
                    G.transform.parent = container.transform;
                    yield return new WaitForSeconds(8);
                }
            }
            else if(sort == 3)
            {
                Sp = true;
                if(Sp == true)
                {
                    Vector3 pos = new Vector3(Random.Range(-5.8f, 5.8f),-5,0); 
                    GameObject G = Instantiate(Speed, pos, Quaternion.identity);
                    G.transform.parent = container.transform;
                    yield return new WaitForSeconds(8);
                }
            }
        }
    }
        
}
