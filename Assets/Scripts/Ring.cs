using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {
	public float speed=80;
    public ParticleSystem particles;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            particles.Play();
            gameObject.SetActive(false);
        }
    }

	// Continous rotation
	void Update () {
		transform.Rotate(Vector3.up, speed*Time.deltaTime);
	}
}
