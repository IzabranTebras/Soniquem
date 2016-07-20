using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {
	public float speed=80;

	// Update is called once per frame
	void Update () {
		//Continous rotation
		transform.Rotate(Vector3.up, speed*Time.deltaTime);

		if (Input.anyKey) {  //cambiar input.anyKey por colision con Sonic
			ParticleSystem particles = GetComponentInChildren<ParticleSystem>();
			particles.Play();
		}
	}
}
