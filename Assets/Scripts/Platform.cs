using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Platform : MonoBehaviour
{
   
    float speedY = 40f;

   
    void Update()
    {
        transform.Rotate(0, speedY * Time.deltaTime, 0);
    }
}
