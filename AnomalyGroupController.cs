using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyGroupController : MonoBehaviour
{
    [Header("Objetos que aparecerán cuando la anomalía esté activa")]
    public GameObject[] objetosAparecen;

    [Header("Objetos que desaparecerán cuando la anomalía esté activa")]
    public GameObject[] objetosDesaparecen;

    // Cuando la anomalía se activa
    void OnEnable()
    {
        foreach (GameObject obj in objetosAparecen)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        foreach (GameObject obj in objetosDesaparecen)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }

    // Cuando la anomalía se desactiva
    void OnDisable()
    {
        foreach (GameObject obj in objetosAparecen)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        foreach (GameObject obj in objetosDesaparecen)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}
