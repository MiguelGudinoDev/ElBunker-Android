using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiasMenu : MonoBehaviour
{

    public Text Dias;
    public Text DiasLibreta;
    public GameManager gameManager;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        Dias.text = "Dia " + gameManager.diaActual;
        DiasLibreta.text = "Dia " + gameManager.diaActual;
    }
}
