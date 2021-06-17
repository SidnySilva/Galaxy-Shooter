using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    private _GC _GC;
    private Player Player;
    public Transform spawn;
    public GameObject Bullet;
    public GameObject Explosao;
    public Rigidbody2D rdb;

    private  float _FireRate = 2, Temptime, Firechance = 100;
    public float _speed,Tiro =-1000, Life = 1, TempCurva;
    private int X,Y, direcao;
    public int Change;
    public int GainPoints = 10;
        void Start()
    {
        Player = FindObjectOfType(typeof(Player)) as Player;
        _GC = FindObjectOfType(typeof(_GC)) as _GC;
        Y = 1;
    }

    void Update()
    {
        Shoot();
        Move();
    }
    void Move()
    {
        Temptime += Time.deltaTime;
        if(Temptime >= TempCurva)
        {
            Temptime = 0;
            int rand = Random.Range(0,100);
            if(rand <= Change)
            {
                rand = Random.Range(0,100);
                if(rand<50)
                {
                    X=-1;
                    direcao=1;
                }
                else
                {
                    X=1;
                    direcao=-1;
                }
            }
            else
            {
                X=0;
                direcao = 0;
                
            }
        }
        rdb.velocity = new Vector2(X*_speed, Y*_speed);
        
        if(transform.position.y < -6)
        {
            transform.position = new Vector3(Random.Range(-6,6),6,0);
            Destroy(this.gameObject);
        }
    }
        void Shoot()
    {
        int rand;
        Temptime += Time.deltaTime;
        if(Temptime >= _FireRate)
        {
            rand = Random.Range(0,100);
            
            if(rand <= Firechance)
            {
                GameObject prefab = Instantiate(Bullet) as GameObject;
                prefab.transform.position = spawn.position;
                prefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-500));
                Sounds.playSound(sound.Shoot);
                Temptime = 0;
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "Laser":
                hit(1);
            break;
            case "Player":
                {
                    Player.Explodir(1);
                    hit(1);
                }
            break;
            case "PlayerShield":
                hit(1);
            break;
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
            _GC.score += GainPoints;
            Destroy(this.gameObject);
            Sounds.playSound(sound.Destroy);
        }
    }
}
