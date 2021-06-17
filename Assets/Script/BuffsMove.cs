using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsMove : MonoBehaviour
{
    public Player Player;
    public Buffs Buffs;
    private _GC _GC;
    public float speed = -3;
    private Rigidbody2D rdb;
    void Start()
    {
        Player = FindObjectOfType(typeof(Player)) as Player;
        Buffs = FindObjectOfType(typeof(Buffs)) as Buffs;
        _GC = FindObjectOfType(typeof(_GC)) as _GC;
        rdb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
    }
    void Move()
    {
        rdb.velocity = new Vector2(0, speed);
        if (transform.position.y < -6)
        {
            transform.position = new Vector3(Random.Range(-6, 6), 6, 0);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Player":
                Destroy(this.gameObject);
                Sounds.playSound(sound.Power);
                if (Buffs.T == true)
                {
                    Player.powerUp();
                }
                else if (Buffs.Sh == true)
                {
                    Player.ShieldUp();
                }
                else if (Buffs.Sp == true)
                {
                    Player.SpeedUp();
                }
                break;
            case "PlayerShield":
                Destroy(this.gameObject);
                Sounds.playSound(sound.Power);
                if (Buffs.T == true)
                {
                    Player.powerUp();
                }
                else if (Buffs.Sh == true)
                {
                    Player.ShieldUp();
                }
                else if (Buffs.Sp == true)
                {
                    Player.SpeedUp();
                }
                break;
        }
    }

    void OnBecameInvisible()
    {
        if (Buffs.Sh == true)
        {
            Buffs.Sh = false;
        }
        if (Buffs.Sp == true)
        {
            Buffs.Sp = false;
        }
        if (Buffs.T == true)
        {
            Buffs.T = false;
        }
    }

}
