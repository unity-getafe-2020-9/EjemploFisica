using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float temporizador;
    public float radio;
    public float fuerza;
    public float fuerzaAscendente;
    public LayerMask layerMask;
    private List<GameObject> explotados = new List<GameObject>();
    void Start()
    {
        Invoke("Explotar", temporizador);
    }

    private void Explotar()
    {
        //Obtenemos todos los colliders (cantidatos) de la Layer indicada y en un radio de distancia
        Collider[] candidatos = Physics.OverlapSphere(transform.position, radio, layerMask);
        //Recorremos todos los candidatos
        foreach(Collider candidato in candidatos)
        {
            //Si no hay rigidbody, pasamos al siguiente candidato
            if (candidato.GetComponent<Rigidbody>() == null) continue;
            //Preguntamos si no hay ningun obstaculo entre la bomba y el candidato
            if (EstaVisible(candidato.gameObject.transform))
            {
                //Si hay obstaculo, aplica la fuerza
                candidato.gameObject.GetComponent<Rigidbody>().AddExplosionForce(
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
        //Rayo que va desde mi posición hasta la posición del candidato
        Ray rayo = new Ray(transform.position, target.position - transform.position);
        //Dibujamos un rayo en la Scene (desarrollo)
        Debug.DrawRay(transform.position, target.position - transform.position, Color.red, Mathf.Infinity);
        //Obtenemos todos los collider entre la bomba y el candidato que se esta evaluando
        RaycastHit[] rchs = Physics.RaycastAll(rayo);
        //Ordenamos los candidatos por distancia
        System.Array.Sort(rchs, (x, y) => x.distance.CompareTo(y.distance));
        //Recorremos el array de colliders intermedios
        foreach(RaycastHit rch in rchs)
        {
            //Si el collider intermedio es el canditato, devolvemos true
            if (rch.collider.gameObject == target.gameObject)
            {
                //if (target.gameObject.name == "Pedro")//Para probar el Ragdoll
                //{
                //    target.gameObject.GetComponent<RagdollManager>().Morir();
                //}
                return true;
            } else if (rch.collider.gameObject.layer != 9)
            {
                //Devolvemos false, si el collider intermedio no es de la capa de los enemigos (en este ejemplo 9)
                return false;
            }
        }

        /*
        RaycastHit hitInfo;//Contiene la informacion del collider con el que choca el rayo
        Physics.Raycast(rayo, out hitInfo);
        if (hitInfo.transform.gameObject == target.gameObject)
        {
            esVisible = true;
        }
        */
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
