using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGradient : MonoBehaviour
{
	public Color color1;
	public Color color2;
	public float alpha1;
	public float alpha2;
	GradientColorKey[] colorKeys;
	GradientAlphaKey[] alphaKeys;
	Gradient gradient;

    // Start is called before the first frame update
    void Start()
    {
		SetUpColorKeys();
		Texture2D texture = new Texture2D(128, 128);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 128, 128), Vector2.zero);
        GetComponent<SpriteRenderer>().sprite = sprite;
     
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++) //Goes through each pixel
            {
                Color pixelColour = gradient.Evaluate((float)x / (float)texture.width);
                texture.SetPixel(x, y, pixelColour);
            }
        }
        texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void SetUpColorKeys() {
		colorKeys = new GradientColorKey[2];
		alphaKeys = new GradientAlphaKey[2];
		colorKeys[0].color = color1;
		colorKeys[0].time = 0.0f;
		colorKeys[1].color = color2;
		colorKeys[1].time = 1.0f;

		alphaKeys[0].alpha = alpha1;
		alphaKeys[0].time = 0.0f;
		alphaKeys[1].alpha = alpha2;
		alphaKeys[1].time = 1.0f;
		
		gradient = new Gradient();
		gradient.SetKeys(colorKeys, alphaKeys);
	}
}

