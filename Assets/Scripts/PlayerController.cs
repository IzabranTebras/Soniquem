using UnityEngine;
using System.Collections;

enum Movement { Turning = 0, Straight, Jumping}

public class PlayerController : MonoBehaviour {

    private const float maxSpeed = 10.0f;

    public float vSpeed = 0.0f;
    public GameObject pointsList;

    private float speed = 1.0f;
    private Movement movement = Movement.Straight;
    private float turnY = 0.0f;
    private Transform[] points;
    private int nextPoint = 0;
    private Ray toFollowPoint;
    private bool stop = false;
    private Vector3 targetAngle = Vector3.zero;
    private bool inGround = true;

    // If player collides with a follow point then assign the new rotation and change to turning movement
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("NextPoint"))
        {
            if (nextPoint < points.Length)
            {
                coll.enabled = false;
                ++nextPoint;
                // We check if player must go to left or right
                if (Vector3.Angle(transform.position, points[nextPoint].position) > 0.0f && Vector3.Angle(transform.position, points[nextPoint].position) <= 90.0f)
                {
                    movement = Movement.Turning;
                    turnY = transform.eulerAngles.y + 90.0f;
                }
                else
                {
                    movement = Movement.Turning;
                    turnY = transform.eulerAngles.y - 90.0f;
                }
            }
            else
            {
                // If not exists more points then stop the player, is the ending
                stop = true;
            }
        }
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("Wall"))
        {
            transform.Translate(Vector3.right * (-Input.GetAxisRaw("Horizontal")*0.5f));
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Floor"))
        {
            movement = Movement.Straight;
            vSpeed = 0.0f;
        }
    }

    void Awake()
    {
        Transform[] transformPoints = pointsList.GetComponentsInChildren<Transform>();
        points = new Transform[transformPoints.Length-1];
        int i = 0;
        for (int j = 1; j < transformPoints.Length; ++j)
        {
            points[i] = transformPoints[j];
            ++i;
        }
    }

    void FixedUpdate () {

        switch (movement)
        {
            case Movement.Turning:
                transform.eulerAngles = new Vector3(0.0f, Mathf.LerpAngle(transform.eulerAngles.y, turnY, 0.1f), 0.0f);
                if(transform.eulerAngles.y == turnY)
                {
                    movement = Movement.Straight;
                }
                break;

            case Movement.Jumping:
                if(vSpeed > 0.15f)
                {
                    vSpeed = Mathf.Lerp(vSpeed, 0.0f, 0.2f);
                }
                else
                {
                    vSpeed = Mathf.Lerp(vSpeed, 0.3f, 0.2f);
                }
                break;
        }

        if (!stop)
        {
            speed = Mathf.Lerp(speed, maxSpeed, 0.002f);
            if(speed > maxSpeed)
            {
                speed = maxSpeed;
            }

            transform.Translate(Vector3.forward * speed*0.07f);
            transform.Translate(Vector3.up * vSpeed);
            if (movement != Movement.Jumping && Input.GetButtonDown("Jump"))
            {
                movement = Movement.Jumping;
            }
            else if (Input.GetButton("Horizontal"))
            {
                transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal")*0.07f);
            }
        }
    }
}
