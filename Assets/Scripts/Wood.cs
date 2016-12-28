using UnityEngine;
using System.Collections;

public class Wood : MonoBehaviour {

    public Rigidbody playerRigid = null;
    public float forceApplied = 12.0f;
    public float speed = 5.0f;

    void Update()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x+ forceApplied*Time.deltaTime, transform.localEulerAngles.y, transform.localEulerAngles.z);
        transform.Translate(transform.right * Time.deltaTime*speed);
    }

    void OnColliderEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRigid.AddForce(Vector3.up * forceApplied, ForceMode.VelocityChange);
        }
    }
}
