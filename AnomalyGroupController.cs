using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyGroupController : MonoBehaviour
{
    [Header("Objetos que aparecerán")]
    public GameObject[] objetosAparecen;

    [Header("Objetos que desaparecerán")]
    public GameObject[] objetosDesaparecen;

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
