using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RecogerMunicion : MonoBehaviour
{
    ArmaController controladorArma;
    public Text textoCoger;
    void Start()
    {
        controladorArma = ArmaController.FindObjectOfType<ArmaController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && controladorArma.armaActual != null)
        {
            textoCoger.gameObject.SetActive(true);
            ; if (Input.GetKeyDown(KeyCode.E))
            {
                controladorArma.armaActual.cargadorMax += controladorArma.armaActual.municion * 4;
                textoCoger.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textoCoger.gameObject.SetActive(false);
        }

    }
}
