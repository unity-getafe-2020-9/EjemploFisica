using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float speed;
    


    CharacterController cc;
    float w;
    float x;
    float altitud;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Direccion y avance
        x = Input.GetAxis("Horizontal");
        w = Input.GetAxis("Vertical");

        //Elevacion
        if (Input.GetKey(KeyCode.PageUp)){
            altitud = 0.1f;
        } else if (Input.GetKey(KeyCode.PageDown))
        {
            altitud = -0.1f;
        } else
        {
            altitud = 0;
        }

        //Movimiento en tierra (no afecta la elevacion)
        cc.SimpleMove(new Vector3(0, 0, w * speed));
        //Movimiento en el aire
        //cc.Move(new Vector3(0, altitud, w * speed));
    }
}
