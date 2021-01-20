using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    bool dragging;
    CapsuleCollider2D collider;
    Rigidbody2D rigidBody;
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        collider = GetComponent<CapsuleCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0)) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(!dragging && collider.OverlapPoint(pos)) {
                dragging = true;
                lastPos = pos;
            }
        } else if(dragging) {
            if(Input.GetMouseButton(0)) {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //transform.position += (pos - lastPos);
                rigidBody.MovePosition(transform.position + (pos - lastPos));
                lastPos = pos;
            }
        } else {
            dragging = false;
        }
    }
}
