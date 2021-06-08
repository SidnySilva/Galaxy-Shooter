using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GC : MonoBehaviour
{

    public int score;
    public Text Pontuacao;
    void Start()
    {

    }

    
    void Update()
    {
        Pontuacao.text = score.ToString();
        // Pontuacao.text = BossLife.ToString();
    }
}
