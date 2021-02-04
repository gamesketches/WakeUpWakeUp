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
    public GameObject blindsBoltGameObject;

    public Animator Shadow1;
    public Animator Shadow2;
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
            blindsBoltGameObject.transform.position = new Vector3(-9.25f, 10, 0);
            blindsHaveBeenOpened = true;
            srBlinds.sprite = openBlinds;
            OpenBlindsAllTheWay();
            myAlpha -= .05f;
            sr.color = new Color(0, 0, 0, myAlpha);
            if (myAlpha <= -5) {
                Destroy(gameObject);
                //Destroy(blindsBoltGameObject.gameObject);
            }
        }
        else {
            sr.color = new Color(0, 0, 0, myAlpha);
        }
        
    }

    public void OpenBlindsACrack()
    {
        Shadow1.Play("SpotlightOpenCrack");
        Shadow2.Play("SpotlightOpenCrack");
    }

    public void OpenBlindsAllTheWay() {
        Shadow1.Play("SpotlightOpenFull");
        Shadow2.Play("SpotlightOpenFull");
    }
}
