using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Falas Falas;
    private Vidas Vidas;
    private Sounds Sounds;
    private SpawnManager SpawnManager;
    private Player Player;
    private Shoot Shoot;
    private Buffs Buffs;
    private BossBuff BossBuff;
    private _GC _GC;
    private Boss Boss;
    
    void Start()
    {
        Player = FindObjectOfType(typeof(Player)) as Player;
        Boss = FindObjectOfType(typeof(Boss)) as Boss;
        Falas = FindObjectOfType(typeof(Falas)) as Falas;
        Vidas = FindObjectOfType(typeof(Vidas)) as Vidas;
        Shoot = FindObjectOfType(typeof(Shoot)) as Shoot;
        Buffs = FindObjectOfType(typeof(Buffs)) as Buffs;
        BossBuff = FindObjectOfType(typeof(BossBuff)) as BossBuff;
        Sounds = FindObjectOfType(typeof(Sounds)) as Sounds;
        _GC = FindObjectOfType(typeof(_GC)) as _GC;
        SpawnManager = FindObjectOfType(typeof(SpawnManager)) as SpawnManager;

        BossBuff.enabled = false;
        Boss.enabled = false;
        Falas.Type();
        Shoot.enabled = false;
        Falas.W.SetActive(false);
        Buffs.Shield.SetActive(false);
        Buffs.Triple.SetActive(false);
        Buffs.Speed.SetActive(false);
        Buffs.enabled = false;
        SpawnManager.asteroid.SetActive(false);
        SpawnManager.enemy.SetActive(false);
        SpawnManager.enabled = false;
        Player.Speed = 0;

    }
    void Update()
    {
        EndFase();
    }
    
    public void Go()
    {
        Player.Speed = 4;
        SpawnManager.asteroid.SetActive(true);
        SpawnManager.enemy.SetActive(false);
        SpawnManager.enabled = true;
        Falas.Texto.enabled = false;
        Buffs.enabled = true;
        Buffs.Triple.SetActive(false);
        Buffs.Shield.SetActive(true);
        Buffs.Speed.SetActive(true);
    }
    public void Go2()
    {
         Player.Speed = 4;
        Shoot.enabled = true;
        SpawnManager.asteroid.SetActive(false);
        SpawnManager.enemy.SetActive(true);
        SpawnManager.enabled = true;
        Falas.Texto.enabled = false;
        Buffs.enabled = true;
        Buffs.Shield.SetActive(true);  
        Buffs.Triple.SetActive(true);
        Buffs.Speed.SetActive(true);   
    }
    public void Go3()
    {
        Player.Speed = 4;
        Shoot.enabled = true;
        SpawnManager.enemy.SetActive(true);
        SpawnManager.asteroid.SetActive(true);
        SpawnManager.enabled = true;
        Falas.Texto.enabled = false;
        Buffs.enabled = true;
        Buffs.Shield.SetActive(true);  
        Buffs.Triple.SetActive(true);
        Buffs.Speed.SetActive(true);   
    }
    public void Go4()
    {
        _GC.score = 200;
        Player.Speed = 4;
        Shoot.enabled = true;
        Boss.enabled = true;
        Falas.Texto.enabled = false;
        Buffs.enabled = true;
        BossBuff.enabled = true;
        Buffs.Shield.SetActive(true);  
        Buffs.Triple.SetActive(true);
        Buffs.Speed.SetActive(true);   
    }
    void EndFase()
    {
        if(_GC.score >= 500 && Falas.fase1 == true && Player.Live == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Falas.W.SetActive(true);
            Shoot.enabled = false;
            SpawnManager.enemy.SetActive(false);
            SpawnManager.asteroid.SetActive(false);
            SpawnManager.enabled = false;
            Falas.Texto.enabled = false;
            Buffs.enabled = false;
            Buffs.Shield.SetActive(false);  
            Buffs.Triple.SetActive(false);
            Buffs.Speed.SetActive(false);  
            Player.Life = 4; 
        }
        if(_GC.score >= 500 && Falas.fase2 == true && Player.Live == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Falas.W.SetActive(true);
            Shoot.enabled = false;
            SpawnManager.enemy.SetActive(false);
            SpawnManager.asteroid.SetActive(false);
            SpawnManager.enabled = false;
            Falas.Texto.enabled = false;
            Buffs.enabled = false;
            Buffs.Shield.SetActive(false);  
            Buffs.Triple.SetActive(false);
            Buffs.Speed.SetActive(false); 
            Player.Life = 4;  
        }
        if(_GC.score >= 1000 && Falas.fase3 == true && Player.Live == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Falas.W.SetActive(true);
            Shoot.enabled = false;
            SpawnManager.enemy.SetActive(false);
            SpawnManager.asteroid.SetActive(false);
            SpawnManager.enabled = false;
            Falas.Texto.enabled = false;
            Buffs.enabled = false;
            Buffs.Shield.SetActive(false);  
            Buffs.Triple.SetActive(false);
            Buffs.Speed.SetActive(false); 
            Player.Life = 4;  
        }
        if(Boss.Life == 0 && Falas.fasefinal == true && Player.Live == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Falas.W.SetActive(true);
            Shoot.enabled = false;
            SpawnManager.enemy.SetActive(false);
            SpawnManager.asteroid.SetActive(false);
            SpawnManager.enabled = false;
            Falas.Texto.enabled = false;
            Buffs.enabled = false;
            Buffs.Shield.SetActive(false);  
            Buffs.Triple.SetActive(false);
            Buffs.Speed.SetActive(false);  
            Player.Life = 4; 
        }
        
        
    }
}
