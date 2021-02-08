using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeBehavior : MonoBehaviour
{
    public AudioSource trumpets;
	static int shoesWorn;
    // Start is called before the first frame update
    void Start()
    {
        shoesWorn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "foot" && transform.parent == null) {
			transform.parent = other.gameObject.transform;
			shoesWorn++;
            //transform.localPosition = Vector3.zero;
            if (shoesWorn >= 2 && !WinText.beenTrig) {
                trumpets.Play();
                AddWobble.bedSounds = false;
                WinText.ActivateWinScreen();
            } else Debug.Log(shoesWorn);
			
        }
    }
}
