using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "enemy":
              Destroy(this.gameObject);
            break;

            case "Boss":
                Destroy(this.gameObject);
            break;

            case "BossShield":
                Destroy(this.gameObject);
            break;
        }
    }
}
