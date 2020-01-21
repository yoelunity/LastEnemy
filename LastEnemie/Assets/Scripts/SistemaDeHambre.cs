using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SistemaDeHambre : MonoBehaviour
{
    FirstPersonPlayerController player;
    public float hambreTotal;
    public float hambreActual;
    public float hambreTimer;
    public Text textoHambre;
    void Start()
    {
        player = FirstPersonPlayerController.FindObjectOfType<FirstPersonPlayerController>();
        hambreActual = hambreTotal;
        hambreTimer = 1;
    }


    void Update()
    {
        hambreTimer += Time.deltaTime;
        textoHambre.text = "Hambre:"+hambreActual + "/" + hambreTotal;
        if ((int)hambreTimer % 5 == 0 && hambreActual >0)
        {
            hambreActual--;
            hambreTimer++;
        }
        if ((int)hambreTimer % 10 == 0 && hambreActual == 0)
        {
            player.vidaActual--;
            hambreTimer++;
        }
        if (hambreTimer >= 21)
        {
            hambreTimer = 0;
        }
    }
}
