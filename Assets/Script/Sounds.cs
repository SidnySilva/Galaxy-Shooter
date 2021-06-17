using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum sound
{
    Shoot, Destroy, Power, Win
}
public class Sounds : MonoBehaviour
{
    public AudioClip shoot, destroy, power, win;
    private AudioSource audi;
    public static Sounds instance;
    void Start()
    {
        audi = GetComponent<AudioSource>();
        instance = this;
    }

    public static void playSound(sound currentSound)
    {
        switch (currentSound)
        {
            case sound.Shoot:
                instance.audi.PlayOneShot(instance.shoot);
                break;

            case sound.Power:
                instance.audi.PlayOneShot(instance.power);
                break;

            case sound.Destroy:
                instance.audi.PlayOneShot(instance.destroy);
                break;
            case sound.Win:
                instance.audi.PlayOneShot(instance.win);
                break;
        }
    }
}
