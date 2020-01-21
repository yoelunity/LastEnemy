using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaApuntado : MonoBehaviour
{
    public GameObject arma;
    public GameObject posicionApuntar;
    public GameObject posicionOriginal;


    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
           arma.transform.position = Vector3.Lerp(posicionOriginal.transform.position, posicionApuntar.transform.position, 1);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            arma.transform.position = Vector3.Lerp(posicionApuntar.transform.position, posicionOriginal.transform.position, 1);
        }

    }
}
