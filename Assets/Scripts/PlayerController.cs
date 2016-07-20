using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private float HorizMovement;
    private float VerticalMovement;
    private Vector3 moveDirection;
    private float vSpeed = 0.0f;
    private float speed = 30.0f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update () {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
