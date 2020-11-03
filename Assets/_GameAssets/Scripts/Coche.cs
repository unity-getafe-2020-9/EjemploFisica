using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour
{
    public float speed;
    public float angularSpeed;
    public WheelCollider[] wc;
    void FixedUpdate()
    {
        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");
        foreach(WheelCollider rueda in wc)
        {
            rueda.motorTorque = speed * forward;
        }
        wc[0].steerAngle = angularSpeed * side;
        wc[1].steerAngle = angularSpeed * side;
    }
}
