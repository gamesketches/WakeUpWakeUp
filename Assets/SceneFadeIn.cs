using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFadeIn : MonoBehaviour
{

	public AudioSource backgroundMusic;
	Texture2D darkness;

	public float fadeSpeed = 0.01f;
	
	int drawDepth = -1000;
	float alpha = 1.0f;
	int fadeDir = -1;

	void OnGUI() {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		backgroundMusic.volume = 1 - alpha;

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), darkness);
	}

	public float BeginFade(int direction){
		fadeDir = direction;
		return (fadeSpeed);
	}
    
	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
		darkness = new Texture2D(2, 2);
		darkness.SetPixels(new Color[]{Color.black, Color.black, Color.black, Color.black});
		darkness.Apply(false);
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		BeginFade(-1);
	}
}
