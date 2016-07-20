using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonTill : MonoBehaviour {

	private Image image;
	private Text text;
	private Color aux;
	private bool alpha=false;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		text = GetComponentInChildren<Text> ();
	}

	// Update is called once per frame
	void Update () {
		aux = image.color;
		if (alpha == false) {
			aux.a -= 0.02f;
			text.color = aux;
			image.color = aux;
			if (image.color.a <= 0.0f){
				alpha = true;
			}
		} else {
			aux.a += 0.02f;
			text.color = aux;
			image.color = aux;
			if (image.color.a >= 1.0f){
				alpha = false;
			}
		}

		if (Input.anyKey) {
			enabled = false;
			DestroyImmediate(image);
			DestroyImmediate(text);
		}
	}
}
