using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBalloon : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float SmoothRate = 0.125f;
    private Vector3 Distance;

    void Start()
    {
        Distance = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 newposition = Vector3.Lerp(transform.position, target.position + Distance, SmoothRate);
        Vector3 position = new Vector3(transform.position.x, newposition.y, transform.position.z);
        transform.position = position;
    }
}
