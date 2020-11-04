using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManager : MonoBehaviour
{
    Rigidbody[] rigideces;
    void Start()
    {
        rigideces = GetComponentsInChildren<Rigidbody>();    
        foreach(Rigidbody rigidbody in rigideces)
        {
            rigidbody.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Morir();
        }
    }
    public void Morir()
    {
        foreach (Rigidbody rigidbody in rigideces)
        {
            GetComponent<Animator>().enabled = false;
            rigidbody.isKinematic = false;
        }
    }
}
