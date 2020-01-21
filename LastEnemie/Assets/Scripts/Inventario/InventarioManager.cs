using System.Collections;
using System.Collections.Generic;
using Inventarios;
using UnityEngine;
using UnityEngine.UI;


public class InventarioManager : MonoBehaviour
{
    public Inventario inventario;
    public Consumible consumibleVacio;
    public Text textoPociones;
    public Text textoComida;

    void Start()
    {

        inventario = new Inventario();

        for (int i = 0; i < inventario.casillasNormales.Length; i++)
        {
            inventario.casillasNormales[i] = new Casilla();
        }
        for (int i = 0; i < inventario.casillasConsumibles.Length; i++)
        {
            inventario.casillasConsumibles[i] = new CasillaConsumible();
        }
        #region consumibleVacio
        consumibleVacio = new Consumible();
        consumibleVacio.id = -1;
        consumibleVacio.nombre = "consumibleVacio";
        consumibleVacio.descripcion = "consumibleVacio";
        consumibleVacio.cantidad = -1;
        consumibleVacio.tipo = "consumibleVacio";
        consumibleVacio.usos = -1;
        consumibleVacio.usosMax = -1;
        consumibleVacio.alimento = -1;
        #endregion


    }
    private void Update()
    {
        for (int i = 0; i < inventario.casillasConsumibles.Length; i++)
        {
            if (inventario.casillasConsumibles[i].consumible.tipo == "Pocion")
            {
                textoPociones.text = "Pociones:" + inventario.casillasConsumibles[i].consumible.cantidad;
                break;
            }
            else
            {
                textoPociones.text = "Sin pociones";
            }
        }

        for (int j = 0; j < inventario.casillasConsumibles.Length; j++)
        {
            if (inventario.casillasConsumibles[j].consumible.tipo == "Comida")
            {
                textoComida.text = "Comida:" + inventario.casillasConsumibles[j].consumible.cantidad;
                break;
            }
            else
            {
                textoComida.text = "Sin comida";
            }
        }
        LimpiarInventario();
    }
    public void LimpiarInventario()
    {
        for (int i = 0; i <inventario.casillasConsumibles.Length; i++)
        {
            if (inventario.casillasConsumibles[i].consumible.cantidad <= 0)
            {
                inventario.casillasConsumibles[i].consumible = consumibleVacio;
            }
        }
    }
}
