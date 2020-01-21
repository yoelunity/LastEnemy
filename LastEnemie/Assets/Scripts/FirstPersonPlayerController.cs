using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonPlayerController : MonoBehaviour
{
    #region VARIABLES PLAYER
    float hor;
    float ver;
    public float speed;
    public float jumpForce;
    GameObject player;
    Rigidbody rb;

    [Range(0.0f, 1000.0f)]
    public float sensibilidadCamara;

    Vector3 rotacionActual;
    float minY = -90.0f;
    float maxY = 45.0f;
    RaycastHit hit;

    public LayerMask ground;
    public bool isGrounded;

    [Space]
    public int vidaActual;
    public int vidaMax;
    public Text textoVida;

    #endregion





    void Start()
    {
        vidaActual = vidaMax;

        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponentInParent<Rigidbody>();
        rotacionActual = transform.eulerAngles;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        #region JUMP
        if (Physics.Raycast(transform.position, player.transform.up*-1, out hit, 2.5f, ground))
        {
            isGrounded = true;
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            }
        }
        else {isGrounded = false; }
        #endregion

        #region ROTACION Y MOVIMIENTO
        float mouseX = Time.deltaTime * sensibilidadCamara * Input.GetAxis("Mouse X");

        player.transform.Rotate(Vector3.up * mouseX);

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        player.transform.Translate(hor * speed * Time.deltaTime, 0, ver * speed * Time.deltaTime);

        rotacionActual.x -= Input.GetAxis("Mouse Y") * sensibilidadCamara * Time.deltaTime;
        rotacionActual.x = Mathf.Clamp(rotacionActual.x, minY, maxY);
        transform.localEulerAngles = rotacionActual;
        #endregion

        textoVida.text = "Vida:" + vidaActual+"/"+vidaMax;
    }
}
