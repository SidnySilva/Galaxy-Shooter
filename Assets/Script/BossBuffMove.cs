using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBuffMove : MonoBehaviour
{
    private int speed = 20;
    public GameObject boss;
    public Transform container;
    private Rigidbody2D rdb;
    private Boss Boss;
    private BossBuff BossBuff;
    void Start()
    {
        BossBuff = FindObjectOfType(typeof(BossBuff)) as BossBuff;
        rdb = GetComponent<Rigidbody2D>();
        Boss = FindObjectOfType(typeof(Boss)) as Boss;
    }

   
    void Update()
    {
        Move();
    }
    void Move()
    {
        //rdb.velocity = new Vector3(speed, speed);
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Boss.transform.position, step); 
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "Boss":
                
                Sounds.playSound(sound.Power);
                if(BossBuff.Shield == true)
                {
                    Boss.PowerUp();
                }
                else if(BossBuff.Shot == true)
                {
                    Boss.ShieldUp();
                }
                else if(BossBuff.Speed == true)
                {
                    Boss.SpeedUp();
                }
                Destroy(this.gameObject);
            break;
            case "BossShield":
                
                Sounds.playSound(sound.Power);
                if(BossBuff.Shield == true)
                {
                    Boss.PowerUp();
                }
                else if(BossBuff.Shot == true)
                {
                    Boss.ShieldUp();
                }
                else if(BossBuff.Speed == true)
                {
                    Boss.SpeedUp();
                }
                Destroy(this.gameObject);
            break;

            // case "Player":               
            //     Sounds.playSound(sound.Destroy);
            //     Destroy(this.gameObject);
            // break;

            // case "Bullet":               
            //     Sounds.playSound(sound.Destroy);
            //     Destroy(this.gameObject);
            // break;
        }
    }
}
