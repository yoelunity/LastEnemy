using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPlayer : MonoBehaviour
{
    public Rigidbody rb;
    FirstPersonPlayerController player;
    ArmaController controladorArma;
    float timeToDestroy;
    void Start()
    {
        controladorArma = ArmaController.FindObjectOfType<ArmaController>();
        player = FirstPersonPlayerController.FindObjectOfType<FirstPersonPlayerController>();
    }

    void Update()
    {
        timeToDestroy += Time.deltaTime;
        if(timeToDestroy >= 3)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        timeToDestroy = 0;
    }
}
