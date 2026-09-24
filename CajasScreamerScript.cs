using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajasScreamerScript : MonoBehaviour
{
    [Header("Cajas en cinematic")]
    public GameObject[] cajas;      
    public AudioSource sonido;

    private bool cinematicActivo = true;

    private void OnTriggerEnter(Collider other)
    {
        if (cinematicActivo && other.CompareTag("Player"))
        {
            foreach (GameObject caja in cajas)
            {
                Rigidbody rb = caja.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false; 
                }
                sonido.Stop();
                sonido.Play();
            }

            cinematicActivo = false;
            Debug.Log("Cinematic desactivado (Rigidbody)");
        }
    }
}
