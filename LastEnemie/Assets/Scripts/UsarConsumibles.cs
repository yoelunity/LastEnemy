using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsarConsumibles : MonoBehaviour
{
    FirstPersonPlayerController player;
    InventarioManager inventarioPlayer;
    SistemaDeHambre hambre;
    void Start()
    {
        hambre = SistemaDeHambre.FindObjectOfType<SistemaDeHambre>();
        player = FirstPersonPlayerController.FindObjectOfType<FirstPersonPlayerController>();
        inventarioPlayer = InventarioManager.FindObjectOfType<InventarioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < inventarioPlayer.inventario.casillasConsumibles.Length; i++)
            {
                if (inventarioPlayer.inventario.casillasConsumibles[i].consumible.tipo == "Pocion" && inventarioPlayer.inventario.casillasConsumibles[i].consumible.cantidad > 0 && player.vidaActual<player.vidaMax)
                {
                    if (player.vidaActual < player.vidaMax - 1)
                    {
                        player.vidaActual++;
                    }
                    else
                    {
                        player.vidaActual = player.vidaMax;
                    }
                    inventarioPlayer.inventario.casillasConsumibles[i].consumible.cantidad--;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            for (int i = 0; i < inventarioPlayer.inventario.casillasConsumibles.Length; i++)
            {
                if (inventarioPlayer.inventario.casillasConsumibles[i].consumible.tipo == "Comida" && inventarioPlayer.inventario.casillasConsumibles[i].consumible.cantidad > 0 && hambre.hambreActual < hambre.hambreTotal)
                {
                    if (hambre.hambreActual < hambre.hambreTotal - 1)
                    {
                        hambre.hambreActual++;
                    }
                    else
                    {
                        hambre.hambreActual = hambre.hambreTotal;
                    }
                    inventarioPlayer.inventario.casillasConsumibles[i].consumible.cantidad--;
                }
            }
        }
    }
}
