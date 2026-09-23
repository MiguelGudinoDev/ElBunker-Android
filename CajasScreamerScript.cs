using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajasScreamerScript : MonoBehaviour
{
    [Header("Cajas en cinematic")]
    public GameObject[] cajas;      // Todas las cajas que están en cinematic
    public AudioSource sonido;

    private bool cinematicActivo = true; // Para que solo se desactive una vez

    private void OnTriggerEnter(Collider other)
    {
        if (cinematicActivo && other.CompareTag("Player"))
        {
            foreach (GameObject caja in cajas)
            {
                Rigidbody rb = caja.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false; // Desactiva el cinematic, ahora la física controla la caja
                }
                sonido.Stop();
                sonido.Play();
            }

            cinematicActivo = false; // Para que solo pase una vez
            Debug.Log("Cinematic desactivado (Rigidbody)");
        }
    }
}
