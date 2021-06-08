using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoros : MonoBehaviour
{
    private _GC _GC;
    public  float _speed, rote;
    private Player Player;
    private Rigidbody2D rdb;
    public GameObject Explosao;
    private int Gain = 10;
    private int Life=1;
    void Start()
    {
        Player = FindObjectOfType(typeof(Player)) as Player;
        _GC = FindObjectOfType(typeof(_GC)) as _GC;
        rdb = GetComponent<Rigidbody2D>();
        rote = (Random.Range(-50, 50));
        var t = Random.Range(0.3f, 1f);
        transform.localScale = new Vector3(t,t,t);
    }

    void Update()
    {     
        Move();
    }
    void Move()
    {
        transform.Rotate(Vector3.forward * rote * Time.deltaTime);
        rdb.velocity = new Vector2(0, _speed);
        if(transform.position.y < -6)
        {
            transform.position = new Vector3(Random.Range(-6,6),6,0);
            Destroy(this.gameObject);
            _GC.score += Gain;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       
        if(col.gameObject.tag == "Laser")
        {
            Destroy(this.gameObject);
            hit(1);
        }
       
        if(col.gameObject.tag == "EnemyLaser")
        {
            Destroy(this.gameObject);
            hit(1);
        }
        if(col.gameObject.tag == "Player")
        {
             Destroy(this.gameObject);
            hit(1); 
            Player.Explodir(1); 
            if(Player.Life == 0)
            {
                Player.Explodir(1);
                hit(1);
            }
        }
        if(col.gameObject.tag == "PlayerShield")
        {
            Destroy(this.gameObject);
            hit(1);
        }
    }
    void hit(int dano)
    {
        Life -= dano;
        if(Life <=0)
        {
            GameObject TempPrefab = Instantiate(Explosao) as GameObject;
            TempPrefab.transform.position = transform.position;
            TempPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
            _GC.score += 10;
            Destroy(this.gameObject);
            Sounds.playSound(sound.Destroy);
        }
    }
}
