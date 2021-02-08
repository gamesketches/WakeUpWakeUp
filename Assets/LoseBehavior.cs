using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseBehavior : MonoBehaviour
{
    public AudioSource trumpets;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "foot" )
        {
                print("LOST");
            if (!WinText.beenTrig) {
                trumpets.Play();
            }
               
             AddWobble.bedSounds = false;
            WinText.ActivateLoseScreen();  
        }
    }
}
