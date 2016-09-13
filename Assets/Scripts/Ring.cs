using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {
	public float speed=80;
    public ParticleSystem particles;

    private MeshRenderer mesh;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            particles.Play();
            mesh.enabled = false;
        }
    }

    void Start()
    {
        mesh = GetComponentInChildren<MeshRenderer>();
    }

	// Rotation loop
	void Update () {
		transform.Rotate(Vector3.up, speed*Time.deltaTime);
	}
}
