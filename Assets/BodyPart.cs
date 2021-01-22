using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    bool dragging;
    PolygonCollider2D collider;
    Rigidbody2D rigidBody;
    Vector3 lastPos;
    Color startColor;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        collider = GetComponent<PolygonCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        startColor = renderer.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(Input.GetMouseButtonDown(0)) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(!dragging && collider.OverlapPoint(pos)) {
                dragging = true;
                lastPos = pos;
            }
        } else if(dragging) {
            renderer.color = Color.grey;
            if(Input.GetMouseButton(0)) {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rigidBody.MovePosition(transform.position + ((pos - lastPos) * Time.fixedDeltaTime));
                lastPos = pos;
            } else {
            dragging = false;
            renderer.color = startColor;
            }
        }
    }
}
