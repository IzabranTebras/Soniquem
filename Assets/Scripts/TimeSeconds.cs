using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeSeconds : MonoBehaviour {

	private Text text;
	private float seconds;
	private int secondsTitle;
	private int minutesTitle;	

	void Start(){
		text = GetComponent<Text> ();
		seconds = 0.0f;
	}
	// Update is called once per frame
	void Update () {
		seconds = seconds + 1 * Time.deltaTime;

		if (seconds >= 1.0f) {
			secondsTitle = int.Parse(text.text.Substring(2)) + 1;
			minutesTitle = int.Parse(text.text.Substring(0,1));
			if (secondsTitle > 59){
				minutesTitle = minutesTitle + 1;
				text.text = minutesTitle.ToString() + ":" + "00";
			}else{
				if (secondsTitle >= 10){
					text.text = minutesTitle + ":" + secondsTitle;
				}else{
					text.text = minutesTitle + ":" + "0" + secondsTitle;
				}
			}
			seconds = 0.0f;
		}
	}
}
