using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionStage {TitleScreen, Blinds, EverythingElse};
public class BodyPart2 : MonoBehaviour
{
    bool dragging;
    PolygonCollider2D collider;
    Rigidbody2D rigidBody;
    Vector3 lastPos;
    Color startColor;
    SpriteRenderer renderer;
    float myWeight;
    bool move;
	public static InteractionStage curStage;
    AudioSource crumple;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BlindString" && !BlindShadowScript.blindsHaveBeenOpened) {
            print("here");
            GameObject BShadow = GameObject.Find("BlindShadow");
            BShadow.GetComponent<BlindShadowScript>().hideMyself = true;
            curStage = InteractionStage.EverythingElse;
			StartCoroutine(GameObject.Find("LightGradient").GetComponent<LightGradient>().FadeOutGradient(0.33f));
        }

        if (collision.gameObject.name == "Glass" || collision.gameObject.name == "Book") {
            collision.gameObject.layer = 11;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        crumple = GameObject.Find("Crumple").GetComponent<AudioSource>();
        dragging = false;
        collider = GetComponent<PolygonCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        startColor = renderer.color;
        myWeight = rigidBody.mass;
		curStage = InteractionStage.TitleScreen;
    }

    private void OnMouseDown()
    {
		if(curStage == InteractionStage.EverythingElse){
			dragging = true;
            crumple.pitch = Random.Range(1.5f, 2.0f);
            crumple.Play();
			//rigidBody.mass = myWeight / 2;
		}
        AddWobble.bedSounds = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
        rigidBody.mass = myWeight;
        AddWobble.bedSounds = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (dragging == true)
        {
           
            rigidBody.MovePosition(Vector3.MoveTowards(transform.position, lastPos, 10 * Time.deltaTime));

        }
        else {
           
        }
    }



}
