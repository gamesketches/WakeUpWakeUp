﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCardBehavior : MonoBehaviour
{
	RectTransform rectTransform;
	Vector2 targetAnchor;
	bool onScreen;
	public float lerpTime;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
	    targetAnchor = rectTransform.anchoredPosition;
		rectTransform.anchoredPosition = new Vector2(0,0);
		onScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && onScreen) {
			StartCoroutine(MoveOffScreen());
			onScreen = false;
		}
    }

	IEnumerator MoveOffScreen() {
		Vector2 startPos = rectTransform.anchoredPosition;
		for(float t = 0; t < lerpTime; t += Time.deltaTime) {
			rectTransform.anchoredPosition = Vector2.Lerp(startPos, targetAnchor, Mathf.SmoothStep(0, 1, t / lerpTime));
			yield return null;
		}
		rectTransform.anchoredPosition = targetAnchor;
	}
}