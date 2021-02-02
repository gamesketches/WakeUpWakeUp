using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    Animator animator;
    BoxCollider2D collider;
    AudioSource alarmBell;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        alarmBell = GetComponent<AudioSource>();
        alarmBell.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0) {
            animator.SetTrigger("TurnOff");
            alarmBell.Stop();
        }
       
    }
}
