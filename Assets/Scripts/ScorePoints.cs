using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorePoints : MonoBehaviour {
	private Text text;

	void Start(){
		text = GetComponent<Text> ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {  //cambiar input.anyKey por colision con Sonic
			text.text = (int.Parse(text.text) + 10).ToString();
		}
	}
}
