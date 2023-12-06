using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float velM;
    Rigidbody2D rb;
    Vector2 movDir;
    public Vector2 posRaton;
    public float angulo;

    public int vida;
    public float tInvin;
    float tGolpeado;

    public Transform puntoDisparo;
    public GameObject proyectil;
    public float velVala;
    public float tDisparo;
    float siguienteDisparo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        inputManager();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time - tGolpeado < tInvin) return;

        if (other.gameObject.CompareTag("dmg"))
        {
            vida -= 1;
            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }
            tGolpeado = Time.time;
        }
    }
    void inputManager()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");

        movDir = new Vector2(movX, movY).normalized;

        posRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //---------Disparar----------
        if (Input.GetButtonDown("Fire1"))
            disparar();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        caminar();

        Vector2 mirarHacia = posRaton - rb.position;
        
        angulo = Mathf.Atan2(mirarHacia.y, mirarHacia.x) * Mathf.Rad2Deg - 180f;
        rb.rotation = angulo;

        if(angulo < -90f || angulo > -270f)
        {
            gameObject.transform.localScale = new Vector3(1, -1, 1);
        }
        if(angulo > -90f || angulo < -270f)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void caminar()
    {
        rb.velocity = new Vector2(movDir.x * velM, movDir.y * velM);
    }
    void disparar()
    {
        if(Time.time > siguienteDisparo)
        {
            siguienteDisparo = Time.time + tDisparo;
            GameObject bala = Instantiate(proyectil, puntoDisparo.position, puntoDisparo.rotation);
            Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
            rbBala.AddForce(-puntoDisparo.right * velVala, ForceMode2D.Impulse);
        }

    }
}
