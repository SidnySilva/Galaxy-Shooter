using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerBuff : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "Player":
              Destroy(this.gameObject);
            break;
            case "PlayerShield":
              Destroy(this.gameObject);
            break;
        }
    }
}
