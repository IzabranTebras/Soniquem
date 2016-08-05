using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu : MonoBehaviour {
	
	public ButtonTill button;

	private RawImage rawImage;
	private Color aux;
	private AudioSource audioSource;

	void Start(){
		rawImage = GetComponent<RawImage> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		if ((button.enabled == false) && (rawImage.color.a == 1.0f)) {
			audioSource.Stop ();
			aux = rawImage.color;
			aux.a -= 0.01f;
			rawImage.color = aux;
		} else {
			if ((button.enabled == false) && (rawImage.color.a > 0.0f)) {
				aux = rawImage.color;
				aux.a -= 0.01f;
				rawImage.color = aux;
			} else {
				if (rawImage.color.a <= 0.0f) {
					Destroy (rawImage);
				}
			}
		}
	}
}
