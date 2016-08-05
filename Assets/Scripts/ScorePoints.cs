using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorePoints : MonoBehaviour {

	private Text text;

	void Start(){
		text = GetComponent<Text> ();
	}

    public void IncrementPoints(int points)
    {
        text.text = (points).ToString();
    }
}
