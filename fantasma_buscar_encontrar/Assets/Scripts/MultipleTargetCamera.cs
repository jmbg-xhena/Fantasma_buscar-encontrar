﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{

    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = 0.5f;

    public float minZoom = 25f;
    public float maxZoom = 10f;
    public float zoomLimiter = 30f;

    Vector3 velocity;
    Camera cam;

    private void Start()
    {
        targets.Add(GameObject.FindGameObjectWithTag("Amelia").transform);
        targets.Add(GameObject.FindGameObjectWithTag("Aron").transform);
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {

        if(targets.Count == 0)
        {
            return;
        }

        Move();
        Zoom();
        
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreastestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);

    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreastestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

}
