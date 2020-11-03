using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuboFisico : MonoBehaviour
{
    public float acceleration;
    Rigidbody rigidbody;
    Text textSpeed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        textSpeed = GameObject.Find("TextSpeed").GetComponent<Text>();
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {

        rigidbody.AddForce(Vector3.forward * acceleration, ForceMode.Force);//Aplicar un fuerza sobre coordenadas absolutas
        //rigidbody.AddRelativeForce(transform.forward * acceleration, ForceMode.Force);//Afecta masa
        //rigidbody.AddRelativeForce(transform.forward * acceleration, ForceMode.Acceleration);//No afecta masa
        //rigidbody.AddRelativeForce(transform.forward * acceleration, ForceMode.Impulse);//Afecta masa, solo aplicar en un frame
        //rigidbody.AddRelativeForce(transform.forward * acceleration, ForceMode.VelocityChange);//Independiente de la masa, incrementa la velocidad
        //rigidbody.AddTorque(Vector3.up * acceleration, ForceMode.Force);//Rotar sobre el eje y
        //rigidbody.AddForceAtPosition(Vector3.forward * acceleration, new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z));
        textSpeed.text = rigidbody.velocity.magnitude.ToString();
    }
}
