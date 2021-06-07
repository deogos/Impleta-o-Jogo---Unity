using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Camera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;

    void Start()
    {
        offset = new Vector3(
            target.position.x - transform.position.x,
            target.position.y - transform.position.y,
            target.position.z - transform.position.z);
    }

    void Update()
    {
        transform.position = target.position - offset;
    }
}
