using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{
	public static WinText instance;
	public float fadeTime;
	Text winText;
	public string[] winQuotes;
	public static bool beenTrig;
    // Start is called before the first frame update
    void Start()
    {
        winText = GetComponent<Text>();
		winText.CrossFadeAlpha(0, 0, true);
		instance = this;
    }

    // Update is called once per frame
    void Update()
    {
		//if(Input.GetKeyDown(KeyCode.Q)) ActivateWinScreen();
        
    }

	public void RollRandomWinQuote() {
		if(winQuotes.Length > 0) {
			winText.text = winQuotes[Mathf.FloorToInt(winQuotes.Length * Random.value)];
		}
	}

	public static void ActivateWinScreen() {
		beenTrig = true;
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Scenery")) {
			SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
			if(spriteRenderer != null) {
				instance.StartCoroutine(instance.FadeOutSprite(spriteRenderer));
			}
		}
		instance.RollRandomWinQuote();	
		instance.StartCoroutine(instance.MoveBodyToCenter());
		instance.winText.CrossFadeAlpha(1, 1, true);
	}

	public IEnumerator FadeOutSprite(SpriteRenderer renderer) {
		Color startColor = renderer.color;
		for(float t = 0; t < fadeTime; t += Time.deltaTime) {
			renderer.color = Color.Lerp(startColor, Color.clear, t / fadeTime);
			yield return null;
		}
		renderer.color = Color.clear;
	}

	public IEnumerator MoveBodyToCenter(){
		GameObject body = GameObject.Find("Body");
		Rigidbody2D[] rbs = body.GetComponentsInChildren<Rigidbody2D>();
		foreach(Rigidbody2D rb in rbs){
			rb.bodyType = RigidbodyType2D.Static;
		}
		Vector3 bodyPos = body.transform.GetChild(0).position;
		Vector3 cameraStart = Camera.main.transform.position;
		bodyPos.z = cameraStart.z;
		for(float t = 0; t < fadeTime; t += Time.deltaTime) {
			//Camera.main.transform.position = Vector3.Lerp(cameraStart, bodyPos, t / fadeTime);
			Camera.main.transform.position = Vector3.Lerp(cameraStart, new Vector3(bodyPos.x, bodyPos.y + 1.5f, bodyPos.z), t / fadeTime);

			yield return null;
		}
		Camera.main.transform.position = new Vector3(bodyPos.x, bodyPos.y + 1.5f, bodyPos.z);
	}
		
}
