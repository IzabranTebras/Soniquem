using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {

    public Rigidbody playerRigid = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRigid.AddForce(Vector3.up*12.0f, ForceMode.VelocityChange);
        }
    }
}
