using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject prefabCubos;
    public float numeroCubos;
    public float fuerza = 1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numeroCubos; i++)
        {
            GameObject cubo = Instantiate(prefabCubos, transform.position, transform.rotation);
            float anguloX = Random.Range(-1.0f, 1.0f);
            float anguloY = Random.Range(-1.0f, 1.0f);
            float anguloZ = Random.Range(-1.0f, 1.0f);
            Vector3 direccion = new Vector3(anguloX, anguloY, anguloZ).normalized;
            cubo.GetComponent<Rigidbody>().AddRelativeForce(
                direccion * fuerza, 
                ForceMode.Impulse);
        }
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        print(Time.deltaTime);
    }
}
