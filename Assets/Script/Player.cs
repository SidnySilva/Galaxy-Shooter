using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("PlayerStatus")]
    public int Life = 3;
    public float Speed = 0;
    //private float _fireRate = 1, _fireNext = -1000, FireSpeed=1000;
    public GameObject Explosao;
    public Animator Anim;
    public Transform Spawn;
    public Rigidbody2D rdb;
    public GameObject bullet;
    public GameObject ExtraShoot, Shield, Boost;

    private Buffs Buffs;
    private  Falas Falas;
    public GameObject Gameover, stop;
    private _GC _GC;
    private  Vidas Vidas;
    private FadeShield FadeShield;
    private SpawnManager SpawnManager;
    public bool Over, Live;

 

    void Start()
    {
        Buffs = FindObjectOfType(typeof(Buffs)) as Buffs;
        _GC = FindObjectOfType(typeof(_GC)) as _GC;
        FadeShield = FindObjectOfType(typeof(FadeShield)) as FadeShield;
        Vidas = FindObjectOfType(typeof(Vidas)) as Vidas;
        SpawnManager = FindObjectOfType(typeof(SpawnManager)) as SpawnManager;
        Falas = FindObjectOfType(typeof(Falas)) as Falas;

        Life = 3;
        Live = true;
        Over = false;

        ExtraShoot.SetActive(false);
        Shield.SetActive(false);
        Boost.SetActive(false);
        Gameover.SetActive(false);
        stop.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    void Update()
    {
        Move();
    }
    
    
    //PLAYER///////////////////////////////////////////////////////////////////////////////////
    private  void Move()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Vector3 D = new Vector3(h,v,0);
        transform.Translate(D*Speed *Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.30f,8.30f),Mathf.Clamp(transform.position.y,-4.5f,4.5f),0);
        if(h>0)
        {
            Anim.SetInteger("Move",1);
        }
        else if(h<0)
        {
            Anim.SetInteger("Move", -1);
        }
        else
        {
            Anim.SetInteger("Move", 0);
        }
    }

    public void Explodir(int dano)
    {
        Life -= dano;
        LifeLoss();
        if(Life <=0)
        {
            
            GameObject TempPrefab = Instantiate(Explosao) as GameObject;
            TempPrefab.transform.position = transform.position;
            TempPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
            Destroy(this.gameObject);
            Sounds.playSound(sound.Destroy);
            Gameover.SetActive(true);
            Over = true;
            Live = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
    }
    void LifeLoss()
    {   
        Vidas.UpdateLives(Life);
    }

    //POWERUP//////////////////////////////////////////////////////////////////////////////////
    public void powerUp()
    {
        ExtraShoot.SetActive(true);
        if(Falas.fasefinal == false)
        {
            _GC.score += 20;
        }
        StartCoroutine("powerDown");
    }
    IEnumerator powerDown()
    {
        yield return new WaitForSeconds(5f);
        ExtraShoot.SetActive(false);
    }
    public void SpeedUp()
    {
        Speed = 8;
        Boost.SetActive(true);
        if(Falas.fasefinal == false)
        {
            _GC.score += 20;
        }
        StartCoroutine("SpeedDown");
    }
    IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(5f);
        Boost.SetActive(false);
        Speed = 4;
    }

    public void ShieldUp()
    {
        if(Falas.fasefinal == false)
        {
            _GC.score += 20;
        }
        if(Life <3)
        {
            Life += 1;
            Vidas.UpdateLives(Life);
        }
        else if(Life == 3)
        { 
            Shield.SetActive(true);
        }
        StartCoroutine("ShieldDown");
    }
    IEnumerator ShieldDown()
    {
        
        yield return new WaitForSeconds(5f);
        Shield.SetActive(false);
        
        
    }
    //POWERUP//////////////////////////////////////////////////////////////////////////////////
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Boss")
        {
            Explodir(1);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "BossShield")
        {
            Explodir(1);
        }
    }
    

}
