using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    public float vSpeed = 0.0f;
    public float speed = 30.0f;
    public GameObject pointsList;

    private Transform[] points;
    private int nextPoint = 0;
    private Ray toFollowPoint;
    private bool stop = false;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("NextPoint"))
        {
            if (nextPoint < points.Length)
            {
                coll.enabled = false;
                ++nextPoint;
                transform.LookAt(points[nextPoint].position);
            }
            else
            {
                stop = true;
            }
        }
    }

    void Start()
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

    void Update () {

        if (!stop)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 10);
            if (Input.GetButton("Jump"))
            {
                transform.Translate(Vector3.up * 2);
            }
            else if (Input.GetButton("Horizontal"))
            {
                transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal"));
            }
            //Debug.DrawLine(transform.position, points[nextPoint].position);
        }
    }
}
