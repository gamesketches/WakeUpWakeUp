using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWobble : MonoBehaviour
{
    public Vector3 defaultPos;
   
    float duration = 1;
    bool wobbleMe;
    Quaternion rotation1;
    Quaternion rotation2;
    public AudioSource bedCreak;
    float raiseSound;
    public static bool bedSounds;
    public AudioSource Snoring;
    float raiseSnoring;
    bool cancelSnoring;

    private void OnMouseEnter()
    {
       wobbleMe = true;

        if (!TitleCardBehavior.startSnoring) {
            cancelSnoring = true;
        }
       
    }


   
    private void OnMouseExit()
    {
      //  bedSounds = false;
        wobbleMe = false;
    }

  

    

    // Start is called before the first frame update
    void Start()
    {
        bedSounds = false;
        defaultPos = gameObject.transform.position;
        rotation1 = Quaternion.Euler(defaultPos);
        rotation2 = Quaternion.Euler(new Vector3(defaultPos.x, defaultPos.y, defaultPos.z + 1));
    }

    private void Update()
    {
        if (wobbleMe)
        {
            var factor = Mathf.PingPong(Time.time / duration, 1);
            // Optionally you can even add some ease-in and -out
            factor = Mathf.SmoothStep(0, 1, factor);
           
            // Now interpolate between the two rotations on the current factor
            transform.rotation = Quaternion.Slerp(rotation1, rotation2, factor);
        }
        

        if (bedSounds && !WinText.beenTrig)
        {
            raiseSound += 0.01f;
           
        }
        else
        {
            raiseSound -= 0.005f;
           
        }

       

        bedCreak.volume = raiseSound;
        raiseSound = Mathf.Clamp(raiseSound, 0, .75f);

        if (gameObject.name == "Mattress")
        {
            if (!cancelSnoring)
            {
                raiseSnoring += 0.025f;
            }
            else
            {

                raiseSnoring -= 0.0075f;
            }
            Snoring.volume = raiseSnoring;
            raiseSnoring = Mathf.Clamp(raiseSnoring, 0, .075f);
        }
    }


}
