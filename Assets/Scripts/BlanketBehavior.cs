using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketBehavior : MonoBehaviour
{
    PolygonCollider2D collider;
    float xScale = 1;
    public float xScaleLimit;
    Vector3 lastPos;
    bool dragging;
    Rigidbody2D rigidbody;
    bool falling;
    public Vector3 blanketTarget;
	Vector3 startPosition;
	public Sprite[] blanketAnimation;
	float mouseDistance;
	public float dragScale = 5;
	SpriteRenderer spriteRenderer;
	public float clickedScale;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
		mouseDistance = 0;
		spriteRenderer = GetComponent<SpriteRenderer>();
		startPosition = transform.position;
		GameObject.Find("RightThigh").GetComponent<Rigidbody2D>().mass = 10;
		GameObject.Find("LeftThigh").GetComponent<Rigidbody2D>().mass = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!dragging && collider.OverlapPoint(pos))
            {
                dragging = true;
                lastPos = pos;
				transform.localScale = new Vector3(clickedScale, clickedScale, clickedScale);
            }
        }
        else if (dragging)
        {
            if (Input.GetMouseButton(0) && !falling)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float offset = Mathf.Abs(pos.magnitude - lastPos.magnitude);
				mouseDistance += (offset * 2);
				float adjustedDistance = Mathf.Clamp(mouseDistance / dragScale, 0, dragScale * blanketAnimation.Length - 1);
				int spriteIndex = Mathf.FloorToInt(adjustedDistance);
				spriteRenderer.sprite = blanketAnimation[spriteIndex];
				if(spriteIndex < blanketAnimation.Length - 1) {
					transform.position = Vector3.Lerp(startPosition, blanketTarget, (float)spriteIndex / (blanketAnimation.Length - 1));
                	//transform.Translate(-offset * 0.5f, 0, 0);
				}
                /*xScale -= offset;
                Vector3 curScale = transform.localScale;
                curScale.x = xScale;
                transform.localScale = curScale;
                if(xScale < xScaleLimit)
                {
                    falling = true;
                    StartCoroutine(RemoveBlanket());
                }*/
                lastPos = pos;
            }
            else
            {
                dragging = false;
				transform.localScale = Vector3.one;
            }
        }
    }

    IEnumerator RemoveBlanket()
    {
        Vector3 startPos = transform.position;
        float offTime = 0.4f;
        blanketTarget.x = transform.position.x;
        for(float t = 0; t < offTime; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, blanketTarget, t / offTime);
            yield return null;
        }
		// Uncomment me when it safe
		GameObject.Find("RightThigh").GetComponent<Rigidbody2D>().mass = 6;
		GameObject.Find("LeftThigh").GetComponent<Rigidbody2D>().mass = 6;
    }
}
