﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    public float vSpeed = 0.0f;
    public float speed = 30.0f;
    public GameObject pointsList;

    private Transform[] points;
    private int nextPoint = 0;
    private Ray toFollowPoint;
    private RaycastHit hit;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("NextPoint"))
        {
            if (nextPoint < points.Length)
            {
                coll.enabled = false;
                ++nextPoint;
                Physics.Raycast(transform.position, points[nextPoint].localPosition, out hit);
                transform.LookAt(hit.point);
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

        transform.Translate(Vector3.forward * Time.deltaTime*10);
        //Physics.Raycast(transform.position, points[nextPoint].localPosition, out hit);
        //transform.LookAt(hit.point);
        //Debug.DrawLine(transform.position, Vector3.forward);
        Debug.DrawLine(transform.position, hit.point);
    }
}
