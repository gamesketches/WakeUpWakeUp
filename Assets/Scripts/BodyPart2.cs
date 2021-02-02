using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BlindString" && !BlindShadowScript.blindsHaveBeenOpened) {
            print("here");
            GameObject BShadow = GameObject.Find("BlindShadow");
            BShadow.GetComponent<BlindShadowScript>().hideMyself = true;
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
    }

    private void OnMouseDown()
    {
        dragging = true;
        rigidBody.mass = myWeight / 2;
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
