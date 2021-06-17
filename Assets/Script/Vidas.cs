using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    private Player Player;
    public Sprite[] Lives;
    public Image Display;
    void Start()
    {
        Player = FindObjectOfType(typeof(Player)) as Player;    
    }

    void Update()
    {

    }
    public void UpdateLives(int currentLives)
    {
        Display.sprite = Lives[currentLives];
    }
}
