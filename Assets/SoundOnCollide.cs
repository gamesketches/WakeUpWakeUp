using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollide : MonoBehaviour
{
    public AudioSource myGroundSound;
    public AudioSource myBodySound;

    bool playedGround;
    bool playedBody;
    public string groundName;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!playedBody)
        {
            if (collision.gameObject.layer == 0)
            {
                myBodySound.pitch = Random.Range(.8f, 1.2f);
                myBodySound.Play();
                playedBody = true;
            }
        }

        if (!playedGround)
        {
            if (collision.gameObject.name == groundName)
            {
                myGroundSound.pitch = Random.Range(.8f, 1.2f);
                myGroundSound.Play();
                playedGround = true;
            }
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
