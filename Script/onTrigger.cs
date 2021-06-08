using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrigger : MonoBehaviour
{

      private Player Player;
      void Start()  
      {
        Player = FindObjectOfType(typeof(Player)) as Player;
      }  
    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "Player":
              Player.Explodir(1);
              Destroy(this.gameObject);
            break;
            case "PlayerShield":
              Destroy(this.gameObject);
            break;
        }
    }
}
