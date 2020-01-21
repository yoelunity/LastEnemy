using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaController : MonoBehaviour
{  
    FirstPersonPlayerController player;
    public GameObject balaPrefab;
    GameObject poolMunicion;

    public Text textoMunicion;
    [SerializeField]
    public Arma armaActual=null;
    public Arma armaPrincipal = null;
    public Arma armaSecundaria = null;


    public List<GameObject> listaMunicion;



    //delay
    public float delay;
    public bool canShoot;

    public bool recarga = false;




    void Start()
    { 
        player = FirstPersonPlayerController.FindObjectOfType<FirstPersonPlayerController>();
        canShoot = true;
        poolMunicion = GameObject.Find("PoolMunicionPlayer");
        listaMunicion = new List<GameObject>();

        armaActual = null;
        armaPrincipal = null;
        armaSecundaria = null;

        for (int i = 0; i < 30; i++)
        {
            GameObject bala = Instantiate(balaPrefab) as GameObject;
            bala.transform.parent = poolMunicion.transform;

            bala.SetActive(false);

            listaMunicion.Add(bala);

        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            armaActual = armaPrincipal;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            armaActual = armaSecundaria;
        }

        if (armaActual != null)
        {

                    if (armaActual.cargador == 0 && armaActual.cargadorMax!=0)
                    {
                        textoMunicion.text = "RECARGAR";
                    }
                    else
                        textoMunicion.text = armaActual.nombre + ":" + armaActual.cargador + "/" + armaActual.cargadorMax;
        }


        if ((Input.GetMouseButtonDown(0)) && (canShoot) && (armaActual!= null))
        {
            if (armaActual.cargador > 0)
            {
                Fire();
                armaActual.cargador--;
            }
        }



        if (Input.GetKeyDown(KeyCode.R) && armaActual.cargadorMax>0)
        {
            recarga = true;
        }


        if (recarga){
            delay += Time.deltaTime;
            Recargando();
        }

    }

    private void Recargando()
    {
        if (delay >= 1f && armaActual.cargadorMax>= armaActual.municion)
        {
            recarga = false;
            delay = 0;
            canShoot = true;
            armaActual.cargadorMax -= (armaActual.municion - armaActual.cargador);
            armaActual.cargador = armaActual.municion;            
        }
        else if (delay >= 1f && armaActual.cargadorMax < armaActual.municion)
        {
            recarga = false;
            delay = 0;
            canShoot = true;
            if (armaActual.cargador + armaActual.cargadorMax <= armaActual.municion)
            {
                armaActual.cargador += armaActual.cargadorMax;
                armaActual.cargadorMax = 0;
            }
            else
            {
                armaActual.cargadorMax -= (armaActual.municion - armaActual.cargador);
                armaActual.cargador = armaActual.municion;
            }
        }
        else
        {
            canShoot = false;
        }

    }

    void Fire()
    {
        
        for (int i = 0; i < listaMunicion.Count; i++)
        {
            if (!listaMunicion[i].activeInHierarchy)
            {
                listaMunicion[i].transform.position = this.transform.position;
                listaMunicion[i].transform.rotation = this.transform.rotation;

                listaMunicion[i].SetActive(true);


                Rigidbody rbBala = listaMunicion[i].GetComponent<Rigidbody>();

                rbBala.useGravity = false;
                rbBala.velocity = listaMunicion[i].transform.forward * 10;
                break;
            }
        }
    }
}
