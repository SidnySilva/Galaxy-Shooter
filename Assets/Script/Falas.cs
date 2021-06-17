using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Falas : MonoBehaviour
{
    [Header("Português")]
    private Controller Controller;
    private Player Player;
    private _GC _GC;
    public Text Texto;
    public string txt, txt2, txt3, txt4, txt5, txt6, txt7, txtwin;
    public float espera;
    public int count = 0;
    public GameObject S, N, W;
    public bool fase1, fase2, fase3, fasefinal, Fim, Inicio;


    void Start()
    {
        Controller = FindObjectOfType(typeof(Controller)) as Controller;
        Player = FindObjectOfType(typeof(Player)) as Player;
        _GC = FindObjectOfType(typeof(_GC)) as _GC;
        StartCoroutine("soletrar", txt);
        count=1;
        S.SetActive(false);
        N.SetActive(false);
        W.SetActive(false);

    }

    
    void Update()
    {
        Type();
        Skip();
        Pause();
    }

    public void Type()
    {
        if(count == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            count ++;
            StartCoroutine("soletrar", txt2);
            
        }
        else if(count == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            count ++;
            StartCoroutine("soletrar", txt3);
        }
        else if(count == 3 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            count ++;
            StartCoroutine("soletrar", txt4);
        }
        else if(count == 4 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            count ++;
            StartCoroutine("soletrar", txt5);
        }
        else if(count == 5 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            count ++;
            StartCoroutine("soletrar", txt6);
        }
        else if(count == 6 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            StartCoroutine("soletrar", txt7);
            count = 7;
        }
        else if(_GC.score >= 100 && Texto == true)
        {
            StartCoroutine("Winning", txtwin);
        }  
    }
    void Skip()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && Inicio == true)
        {
            StopCoroutine("soletrar");
            Texto.text = "";
            count = 7;
            StartCoroutine("soletrar", txt7);
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StopCoroutine("soletrar");
            Texto.text = "";
            count = 7;
            StartCoroutine("StartFase");
        }
    }
    IEnumerator soletrar(string texto)
    {
        if(count <= 7)
        {
            
            int letra = 0;
            Texto.text = "";
            while(letra <= texto.Length -1)
            {
                Texto.text += texto[letra];
                letra += 1;
                yield return new WaitForSeconds(espera);
            }
            if(count >= 7 && Inicio == true)
            {
                yield return new WaitForSeconds(2);
                S.SetActive(true);
                N.SetActive(true);   
            }
            
        }  
        if(count == 7)
        {
            StartCoroutine("StartFase");
        }
        
        
    }
    IEnumerator StartFase()
    {
        if(fase1 == true && count == 7)
        {
            yield return new WaitForSeconds(2);
            Controller.Go();
        }
        else if(fase2 == true && count == 7)
        {
            yield return new WaitForSeconds(2);
            Controller.Go2();
        }
        else if(fase3 == true && count == 7)
        {
            yield return new WaitForSeconds(2);
            Controller.Go3();
        }
        else if(fasefinal == true && count == 7)
        {
            yield return new WaitForSeconds(2);
            Controller.Go4();
        }
        else if(Fim == true && count == 7)
        {
            yield return new WaitForSeconds(2);
            W.SetActive(true);
        }
            
    }
    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Player.Over == false)
        {
            Time.timeScale = 0;
            Player.stop.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
            
    }
    public void Continue()
    {     
        Time.timeScale = 1;
        Player.stop.SetActive(false);    
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    IEnumerator Winning(string texto)
    {
        int letra = 0;
        Texto.text = "";
        while(letra <= texto.Length -1)
        {
            Texto.text += texto[letra];
            letra += 1;
            yield return new WaitForSeconds(espera);
        }
    }
}   

