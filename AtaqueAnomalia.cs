using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtaqueAnomalia : MonoBehaviour
{
    public Canvas ScreamMuerto, ScreamCara, ScreamBruja;
    //public string StriggerCara, StriggerMuerto, StriggerBruja;
    public float segundosScreamer = 2;

    public GameManager manager; //asignar en Inspector

    void Start()
    {
        if (ScreamCara) ScreamCara.gameObject.SetActive(false);
        if (ScreamMuerto) ScreamMuerto.gameObject.SetActive(false);
        if (ScreamBruja) ScreamBruja.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StriggerCara") && ScreamCara != null)
        {
            ScreamCara.gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(OcultarCanvasAnomalia());
        }

        if (other.CompareTag("StriggerMuerto") && ScreamMuerto != null)
        {
            ScreamMuerto.gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(OcultarCanvasAnomalia());
        }

        if (other.CompareTag("StriggerBruja") && ScreamBruja != null)
        {
            ScreamBruja.gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(OcultarCanvasAnomalia());
        }
    }

    IEnumerator OcultarCanvasAnomalia()
    {
        yield return new WaitForSeconds(segundosScreamer);

        if (ScreamMuerto) ScreamMuerto.gameObject.SetActive(false);
        if (ScreamBruja) ScreamBruja.gameObject.SetActive(false);
        if (ScreamCara) ScreamCara.gameObject.SetActive(false);

        if (manager != null)
            manager.ReiniciarJuego();
        else
            Debug.LogWarning("Manager no asignado");


    }
}


