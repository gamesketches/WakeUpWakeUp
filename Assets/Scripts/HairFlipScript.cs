using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairFlipScript : MonoBehaviour
{
	public Sprite[] hairSprites;
	int sprite;
	Rigidbody2D parentBody;
	public float velocityThreshold;
	SpriteRenderer renderer;
	public int frameDelay;
	int frameTimer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
		sprite = 0;
		parentBody = transform.parent.gameObject.GetComponent<Rigidbody2D>();
		frameTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if(frameTimer <= 0) {
			if(parentBody.velocity.magnitude > velocityThreshold) {
				sprite++;
				sprite = sprite % hairSprites.Length;
				frameTimer = frameDelay;
			}
			renderer.sprite = hairSprites[sprite];
		} else frameTimer--;
    }
}
