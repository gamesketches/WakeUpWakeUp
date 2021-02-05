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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BlindString" && !BlindShadowScript.blindsHaveBeenOpened) {
            print("here");
            GameObject BShadow = GameObject.Find("BlindShadow");
            BShadow.GetComponent<BlindShadowScript>().hideMyself = true;
            curStage = InteractionStage.EverythingElse;
        }

        if (collision.gameObject.name == "Glass" || collision.gameObject.name == "Book") {
            collision.gameObject.layer = 8;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
			//rigidBody.mass = myWeight / 2;
		}
    }

    private void OnMouseUp()
    {
        dragging = false;
        rigidBody.mass = myWeight;
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
    }



}
