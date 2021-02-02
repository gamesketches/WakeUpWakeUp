using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindShadowScript : MonoBehaviour
{
    float myAlpha;
    public bool hideMyself;
    SpriteRenderer sr;

    public Sprite openBlinds;
    public static bool blindsHaveBeenOpened;
    public GameObject BlindsGameObject;
    SpriteRenderer srBlinds;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        srBlinds = BlindsGameObject.GetComponent<SpriteRenderer>();

        myAlpha = .99f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hideMyself)
        {
            blindsHaveBeenOpened = true;
            srBlinds.sprite = openBlinds;
            myAlpha -= .05f;
            sr.color = new Color(0, 0, 0, myAlpha);
            if (myAlpha <= 0) {
                Destroy(gameObject);
            }
        }
        else {
            sr.color = new Color(0, 0, 0, myAlpha);
        }
        
    }
}
