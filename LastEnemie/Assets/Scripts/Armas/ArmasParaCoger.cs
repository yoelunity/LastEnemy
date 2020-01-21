using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Inventarios;
public class ArmasParaCoger : MonoBehaviour
{
    public Arma metralleta;
    public Arma pistola;
    public Arma francotirador;
    public Text textoCoger;
    ArmaController controladorArma;

    public enum TiposDeArma
    {
        tipo_Pistola,tipo_Metralleta,tipo_Francotirador
    }

    public TiposDeArma TipoDeArma;



    void Start()
    {
        controladorArma = ArmaController.FindObjectOfType<ArmaController>();

        #region metralleta
        metralleta = new Arma();
        metralleta.id = 1;
        metralleta.nombre = "Metralleta";
        metralleta.descripcion = "A reventar putos culos";
        metralleta.esStackeable = false;
        metralleta.damage = 4;
        metralleta.cantidad = 1;
        metralleta.atkSpeed = 5;
        metralleta.cargadorMax = 300;
        metralleta.municion = 30;
        metralleta.cargador = metralleta.municion;
        metralleta.tipo = "Arma";
        #endregion

        #region francotirador
        francotirador = new Arma();
        francotirador.id = 3;
        francotirador.nombre = "Francotirador";
        francotirador.descripcion = "Cabeza va";
        francotirador.esStackeable = false;
        francotirador.damage = 10;
        francotirador.cantidad = 1;
        francotirador.atkSpeed = 5;
        francotirador.cargadorMax = 10;
        francotirador.municion = 5;
        francotirador.cargador = francotirador.municion;
        francotirador.tipo = "Arma";
        #endregion

        #region pistola
        pistola = new Arma();
        pistola.id = 2;
        pistola.nombre = "Pistola";
        pistola.descripcion = "A petar cabezas";
        pistola.esStackeable = false;
        pistola.damage = 2;
        pistola.cantidad = 1;
        pistola.atkSpeed = 2;
        pistola.cargadorMax = 120;
        pistola.municion = 12;
        pistola.cargador = pistola.municion;
        pistola.tipo = "Arma";
        #endregion

    }

    private void OnTriggerStay(Collider other)
    {

    
        if (other.tag == "Player")
        {          
                    switch (TipoDeArma)
                    {
                    case TiposDeArma.tipo_Metralleta:
                    if (controladorArma.armaPrincipal == null)
                    {
                        controladorArma.armaPrincipal = metralleta;
                        controladorArma.armaActual = metralleta;
                        Destroy(this.gameObject);
                    }
                    else 
                    {
                        textoCoger.gameObject.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            controladorArma.armaPrincipal = metralleta;
                            controladorArma.armaActual = metralleta;
                            textoCoger.gameObject.SetActive(false);
                            Destroy(this.gameObject);
                        }
                    }
                    break;



                    case TiposDeArma.tipo_Pistola:
                    if (controladorArma.armaSecundaria == null)
                    {
                        controladorArma.armaSecundaria = pistola;
                        controladorArma.armaActual = pistola;
                        Destroy(this.gameObject);
                    }
                    else 
                    {
                        textoCoger.gameObject.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            controladorArma.armaSecundaria = pistola;
                            controladorArma.armaActual = pistola;
                            textoCoger.gameObject.SetActive(false);
                            Destroy(this.gameObject);
                        }
                    }
                    break;



                    case TiposDeArma.tipo_Francotirador:
                    if (controladorArma.armaPrincipal == null)
                    {
                        controladorArma.armaPrincipal = francotirador;
                        controladorArma.armaActual = francotirador;
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        textoCoger.gameObject.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            controladorArma.armaPrincipal = francotirador;
                            controladorArma.armaActual = francotirador;
                            textoCoger.gameObject.SetActive(false);
                            Destroy(this.gameObject);
                        }
                    }
                    break;
                    }
            
                    
                
            
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            textoCoger.gameObject.SetActive(false);
        }
    }
}

