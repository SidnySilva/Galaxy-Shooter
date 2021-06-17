using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChange : MonoBehaviour
{
    private Renderer rend;
    private Player Player;
    private Fade Fade;
    void Start()
    {
        rend = GetComponent<Renderer>();
        Player = FindObjectOfType(typeof(Player)) as Player;
    }
    
    public void Jogar(string P)
    {
        StartCoroutine("FadeIn");
        SceneManager.LoadScene(P); 
    }
    public void Menu(string G)
    {
        StartCoroutine("FadeIn");
        SceneManager.LoadScene(G);  
    }
    public void FalseEnd(string F)
    {
        SceneManager.LoadScene(F);
    }
    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator FadeIn()
    {
        for(float f =0; f<=1; f+=0.01f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        
    }
}
