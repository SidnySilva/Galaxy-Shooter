using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy, asteroid;
    [SerializeField]
    private Transform _enemyContainer;
    [SerializeField]
    public bool _StopSpawning = false;
    private Player Player;

    void Start()
    {
        StartCoroutine(Enemy());
        StartCoroutine(Asteroid());
        Player = FindObjectOfType(typeof(Player)) as Player;
        Morte();
        
    }

    void Update()
    {
        OnPlayerDeath();
        
        
    }
    public void Morte()
    {
        if(Player.Life ==0)
        {
            _StopSpawning = true;
        }
    }
    public IEnumerator Enemy()
    {
        while(!_StopSpawning)
        {
           
            Vector3 pos = new Vector3(Random.Range(-8.30f,8.30f),6,0);
            GameObject g = Instantiate(enemy, pos, Quaternion.identity);
            g.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(0.5f); 
        }
    }
    public IEnumerator Asteroid()
    {
        while (!_StopSpawning)
        {
           
            Vector3 po = new Vector3(Random.Range(-8.30f,8.30f),6,0);
            GameObject k = Instantiate(asteroid, po, Quaternion.identity);
            k.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(0.5f);
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
