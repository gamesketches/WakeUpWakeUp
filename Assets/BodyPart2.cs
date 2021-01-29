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

    bool move;

    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        collider = GetComponent<PolygonCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        startColor = renderer.color;
    }

    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (dragging == true)
        {
            rigidBody.MovePosition(Vector3.MoveTowards(transform.position, lastPos, 40 * Time.deltaTime));
        }
    }



}
