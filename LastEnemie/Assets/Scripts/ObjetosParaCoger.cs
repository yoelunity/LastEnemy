using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventarios;

public class ObjetosParaCoger : MonoBehaviour
{
    public Consumible pocion;
    public Consumible comida1;
    InventarioManager inventarioPlayer;
    public enum TiposDeConsumibles
    {
        tipo_Pocion,TipoComida
    }

    public TiposDeConsumibles TipoDeConsumible;
    void Start()
    {
        inventarioPlayer = InventarioManager.FindObjectOfType<InventarioManager>();
        #region pocion
        pocion = new Consumible();
        pocion.id = 1;
        pocion.nombre = "Pocion";
        pocion.descripcion = "Te cura vida";
        pocion.cantidad = 1;
        pocion.tipo = "Pocion";
        pocion.usos = 1;
        pocion.usosMax = 1;
        pocion.alimento = 0;
        #endregion

        #region comida1
        comida1 = new Consumible();
        comida1.id = 1;
        comida1.nombre = "Comida1";
        comida1.descripcion = "Te quita hambre";
        comida1.cantidad = 1;
        comida1.tipo = "Comida";
        comida1.usos = 1;
        comida1.usosMax = 1;
        comida1.alimento = 0;
        #endregion
    }

    private void OnTriggerStay(Collider other)
    {


        if (other.tag == "Player")
        {
            switch (TipoDeConsumible)
            {
                case TiposDeConsumibles.tipo_Pocion:

                    for(int i = 0; i< inventarioPlayer.inventario.casillasConsumibles.Length; i++)
                    {
                        if (inventarioPlayer.inventario.casillasConsumibles[i].consumible.tipo == "Pocion")
                        {
                            inventarioPlayer.inventario.casillasConsumibles[i].consumible.cantidad++;
                            i = inventarioPlayer.inventario.casillasConsumibles.Length;
                            
                            Destroy(this.gameObject);
                        }
                        if(i< inventarioPlayer.inventario.casillasConsumibles.Length)
                        if (inventarioPlayer.inventario.casillasConsumibles[i].consumible.id<0)
                        {
                            inventarioPlayer.inventario.casillasConsumibles[i].consumible = pocion;
                                i = inventarioPlayer.inventario.casillasConsumibles.Length;

                                Destroy(this.gameObject);
                        }

                    }

                    break;

                case TiposDeConsumibles.TipoComida:

                    for (int i = 0; i < inventarioPlayer.inventario.casillasConsumibles.Length; i++)
                    {
                        if (inventarioPlayer.inventario.casillasConsumibles[i].consumible.tipo == "Comida")
                        {
                            inventarioPlayer.inventario.casillasConsumibles[i].consumible.cantidad++;
                            i = inventarioPlayer.inventario.casillasConsumibles.Length;
                           
                            Destroy(this.gameObject);
                        }
                        if (i < inventarioPlayer.inventario.casillasConsumibles.Length)
                            if (inventarioPlayer.inventario.casillasConsumibles[i].consumible.id < 0)
                        {
                            inventarioPlayer.inventario.casillasConsumibles[i].consumible = comida1;
                                i = inventarioPlayer.inventario.casillasConsumibles.Length;
                               
                                Destroy(this.gameObject);
                        }
                    }
                    
                    break;

            }




        }

    }
}
