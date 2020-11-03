using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float temporizador;
    public float radio;
    public float fuerza;
    public float fuerzaAscendente;
    public LayerMask layerMask;
    void Start()
    {
        Invoke("Explotar", temporizador);
    }

    private void Explotar()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radio, layerMask);
        foreach(Collider cubo in cols)
        {
            if (cubo.GetComponent<Rigidbody>() == null) continue;//Si no hay rigidbody, pasa al siguiente

            if (EstaVisible(cubo.transform))
            {
                cubo.gameObject.GetComponent<Rigidbody>().AddExplosionForce(
                    fuerza,
                    transform.position,
                    radio,
                    fuerzaAscendente);
            }
        }
        DesmontarRuedas();
    }

    private bool EstaVisible(Transform target)
    {
        bool esVisible = false;
        //Rayo que va desde mi posición hasta la posición del objetivo
        Ray rayo = new Ray(transform.position, target.position - transform.position);
        Debug.DrawRay(transform.position, target.position - transform.position, Color.red, 10);
        RaycastHit hitInfo;//Contiene la informacion del collider con el que choca el rayo
        Physics.Raycast(rayo, out hitInfo);
        if (hitInfo.transform.gameObject == target.gameObject)
        {
            esVisible = true;
        }
        return esVisible;
    }
    private void DesmontarRuedas()
    {
        GameObject[] piezas = GameObject.FindGameObjectsWithTag("Pieza");
        foreach(GameObject pieza in piezas)
        {
            pieza.transform.SetParent(null);
        }
    }
}
