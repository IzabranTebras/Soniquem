using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RingsCatched : MonoBehaviour {

	private Text text;
	
	void Start(){
		text = GetComponent<Text> ();
	}

    public void IncrementRings(int rings)
    {
        text.text = (rings).ToString();
    }
}
