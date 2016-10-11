using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public ScorePoints score;
    public RingsCatched catchedRings;

    private int rings;
    private int punctuation;

    void Start()
    {
        rings = 0;
        punctuation = 0;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Ring"))
        {
            ++rings;
            punctuation += 10;
            score.IncrementPoints(punctuation);
            catchedRings.IncrementRings(rings);
        }
    }
	
}
