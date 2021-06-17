using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffSet : MonoBehaviour
{
    private Material Material;
    public float speed;
    private float offset;
    void Start()
    {
        Material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += speed * Time.deltaTime;
        Material.SetTextureOffset("_MainTex", new Vector2(0,offset));
    }
}
