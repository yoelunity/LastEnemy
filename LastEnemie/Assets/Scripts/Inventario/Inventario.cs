using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Inventarios
{
    [System.Serializable]
    public class Inventario
    {
        public Casilla[] casillasNormales;
        public CasillaConsumible[] casillasConsumibles;

        public Inventario()
        {
            casillasNormales = new Casilla[2];
            casillasConsumibles = new CasillaConsumible[2];
        }

    }

    [System.Serializable]
    public class Casilla
    {
        public Objeto objeto = new Objeto();
    }
    [System.Serializable]
    public class CasillaConsumible
    {
        public Consumible consumible = new Consumible();
    }

    [System.Serializable]
    public class Objeto
    {
        public string nombre;
        public int id;
        public int cantidad;
        public bool esStackeable;
        public string descripcion;
        public string tipo;


        public Objeto()
        {
            id = -1;
            nombre = "Not Set";
            descripcion = "Not Set";
            esStackeable = false;
            cantidad = 0;

        }

        public Objeto(int id, string nombre, string descripcion, bool esStackeable) : this()
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.esStackeable = esStackeable;
        }

        public Objeto(int id, string nombre, string descripcion, bool esStackeable, int cantidad) : this(id, nombre, descripcion, esStackeable)
        {
            this.cantidad = cantidad;
        }


    }
    [System.Serializable]
    public class Consumible : Objeto
    {
        public int usos = -1;
        public int usosMax = -1;
        public int alimento = -1;
    }
}
