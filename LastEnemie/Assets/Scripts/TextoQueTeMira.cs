using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoQueTeMira : MonoBehaviour
{
    FirstPersonPlayerController player;

    void Start()
    {
        player = FirstPersonPlayerController.FindObjectOfType<FirstPersonPlayerController>();
    }
    void Update()
    {
        this.transform.LookAt(player.transform);
    }
}
