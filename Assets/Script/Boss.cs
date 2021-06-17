using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody2D rdb;
    [SerializeField]
    private GameObject Bullet, Explosao, Shield, ShieldFall, Obj, hurt1, hurt2, Exp1;
    [SerializeField]
    private Transform A, B, C, Destino, S1, S2;
    [SerializeField]
    private Transform[] spw;

    private Player Player;
    private _GC _GC;
    public bool ShieldOn;
    public float speed = 4;
    private int Rota = 0;
    public int sort = 0, rand, sortMove, Life;
    public float TempTime;
    [SerializeField]
    private float _Firenext = 5, _FireRate = 1, Firechance = 50;
    private int X, direcao;
    void Start()
    {
        Player = FindObjectOfType(typeof(Player)) as Player;
        _GC = FindObjectOfType(typeof(_GC)) as _GC;
        Rigidbody2D rdb = GetComponent<Rigidbody2D>();
        GameObject Obj = GetComponent<GameObject>();
        hurt1.SetActive(false);
        hurt2.SetActive(false);
        Shield.SetActive(false);
        ShieldOn = false;
    }

    void Update()
    {
        Move();
        prepare();
    }
    void Move()
    {
        float step = speed * Time.deltaTime;
        Obj.transform.position = Vector3.MoveTowards(Obj.transform.position,Destino.position, step);
        if(Obj.transform.position == Destino.position)
        {
            sortMove = Random.Range(0,4);
            if(sortMove == 1)
            {
                Destino.position = A.position;
            }
            else if(sortMove == 2)
            {
                Destino.position = B.position;
            }
            else if(sortMove == 3)
            {
                Destino.position = C.position;
            }
        }
        if(Life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void prepare()
    {
        TempTime += Time.deltaTime;
        if(TempTime >= _FireRate)
        {
            rand = Random.Range(0,100);
            
            if(rand <= Firechance)
            {
              Shoot(); 
            }
            
        }
    }
    void Shoot()
    {
        GameObject prefab = Instantiate(Bullet) as GameObject;
        prefab.transform.position = spw[Random.Range(0,4)].position;
        prefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-850));
        Sounds.playSound(sound.Shoot);
        TempTime = 0; 

    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(ShieldOn == false && col.gameObject.tag == "Laser" || col.gameObject.tag == "PlayerShield")
        {
            hit(1);
        }
        else if(col.gameObject.tag == "BossBuff1")
        {             
            ShieldUp();
        }
        else if(col.gameObject.tag == "BossBuff2")
        {
            PowerUp();
        } 
        else if(col.gameObject.tag == "BossBuff3")
        {
            SpeedUp();
        }
        else if(col.gameObject.tag == "Player")
        {
            Player.Explodir(1);  
        }
    }
    void hit(int dano)
    {
        Life -= dano;
        _GC.score = Life;
        if(Life == 125)
        {
            GameObject TempPrefab = Instantiate(Exp1) as GameObject;
            TempPrefab.transform.position = S1.transform.position;
            TempPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
            Sounds.playSound(sound.Destroy);
            hurt1.SetActive(true);
        }
        else if(Life == 50)
        {
            GameObject TempPrefab = Instantiate(Exp1) as GameObject;
            TempPrefab.transform.position = S2.transform.position;
            TempPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
            Sounds.playSound(sound.Destroy);
            hurt2.SetActive(true);
        }
        else if(Life ==0)
        {
            GameObject TempPrefab = Instantiate(Explosao) as GameObject;
            TempPrefab.transform.position = transform.position;
            TempPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
            Destroy(this.gameObject);
            Sounds.playSound(sound.Destroy);
        }
    }
    
    public void PowerUp()
    {
        _FireRate = 0.2f;
        Firechance = 5;
        StartCoroutine(powerDown());
    }
    IEnumerator powerDown()
    {
        yield return new WaitForSeconds(5f);
        Firechance = 50;
        _FireRate = 1;
    }
    public void ShieldUp()
    {
        ShieldOn = true;
        _FireRate = 90;
        Firechance = 100;
        Shield.SetActive(true);
        StartCoroutine(ShieldDown());
    }
    IEnumerator ShieldDown()
    {
        int rain = 0;
        while(rain != 10)
        {
            _FireRate = 90;
            TempTime = 0;
            yield return new WaitForSeconds(0.9f);
            GameObject prefab = Instantiate(ShieldFall) as GameObject;
            prefab.transform.position = transform.position;
            rain++;
        }
        yield return new WaitForSeconds(1);
        ShieldOn = false;
        Shield.SetActive(false);
        if(ShieldOn == false)
        {
            _FireRate = 1;
        }
    }
    public void SpeedUp()
    {
        speed = 8;
        StartCoroutine(SpeedDown());
    }
    IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(5);
        speed = 4;
    }
}
