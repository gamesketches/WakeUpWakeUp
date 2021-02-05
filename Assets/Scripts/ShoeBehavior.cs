using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeBehavior : MonoBehaviour
{
    public AudioSource trumpets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "foot") {
            Debug.Log("Winner!!");
			transform.parent = other.gameObject.transform;
            //transform.localPosition = Vector3.zero;
            if (!WinText.beenTrig) {
                trumpets.Play();
                WinText.ActivateWinScreen();
            }
			
        }
    }
}
