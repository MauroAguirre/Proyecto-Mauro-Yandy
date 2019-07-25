using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_controles : MonoBehaviour
{
    public bool direccion = true;
    public float velocidad_movimiento = 5f;
    public float potencia_salto = 14f;
    public float velocidad_salto = 0f;
    public float gravedad = 0.5f;
    public int atacar = 0;
    private Animator animator;
    private SpriteRenderer sprite;
    public GameObject zonaAtaque;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        animator.SetInteger("estado", 3);
        sprite.flipX = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name != "zona ataque")
            animator.SetInteger("estado", 0);
        if (coll.gameObject.name == "zona ataque")
        {
            this.velocidad_salto = potencia_salto;
            this.transform.position += new Vector3(0, +potencia_salto * Time.deltaTime, 0);
            animator.SetInteger("estado", 3);
        }
    }

    void Update()
    {
        if (velocidad_salto > 0)
        {
            this.transform.position += new Vector3(0, +velocidad_salto * Time.deltaTime, 0);
            velocidad_salto -= gravedad;
        }
        switch (animator.GetInteger("estado"))
        {
            case 0:
                //ataque
                if (Input.GetKey(KeyCode.G))
                {
                    animator.SetInteger("estado", 2);
                    atacar = 1;
                }
                else
                {
                    PuedeMoverse();
                }
                PuedeSaltar();
                break;
            case 1:
                animator.SetInteger("estado", 0);
                //ataque
                if (Input.GetKey(KeyCode.G))
                {
                    animator.SetInteger("estado", 2);
                    atacar = 1;
                }
                PuedeMoverSaltar();
                break;
            case 2:
                if (Input.GetKey(KeyCode.G) && atacar==2)
                {
                    animator.SetInteger("estado", 4);
                }
                break;
            case 3:
                if (Input.GetKey(KeyCode.A))
                {
                    this.transform.position += new Vector3(-velocidad_movimiento * Time.deltaTime, 0, 0);
                    animator.SetInteger("estado", 3);
                    if (!direccion)
                    {
                        direccion = true;
                        sprite.flipX = true;
                    }
                }
                else
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        this.transform.position += new Vector3(+velocidad_movimiento * Time.deltaTime, 0, 0);
                        animator.SetInteger("estado", 3);
                        if (direccion)
                        {
                            direccion = false;
                            sprite.flipX = false;
                        }
                    }
                }
                break;
            case 4:
                break;
        }
        
    }
    public void golpe()
    {
        zonaAtaque.AddComponent<Rigidbody>();
        if(direccion)
            zonaAtaque.transform.position = new Vector3(this.transform.position.x-0.5f, this.transform.position.y, 0);
        else
            zonaAtaque.transform.position = new Vector3(this.transform.position.x+0.5f, this.transform.position.y, 0);
    }
    public void terminaAtaque()
    {
        animator.SetInteger("estado",0);
    }
    public void segundoAtaque()
    {
        atacar = 2;
    }
    public void PuedeMoverse()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-velocidad_movimiento * Time.deltaTime, 0, 0);
            animator.SetInteger("estado", 1);
            if (!direccion)
            {
                direccion = true;
                sprite.flipX = true;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.position += new Vector3(+velocidad_movimiento * Time.deltaTime, 0, 0);
                animator.SetInteger("estado", 1);
                if (direccion)
                {
                    direccion = false;
                    sprite.flipX = false;
                }
            }
        }
    }
    public void PuedeSaltar()
    {
        //saltar
        if (Input.GetKey(KeyCode.W))
        {
            this.velocidad_salto = potencia_salto;
            this.transform.position += new Vector3(0, +potencia_salto * Time.deltaTime, 0);
            animator.SetInteger("estado", 3);
        }
    }
    public void PuedeMoverSaltar()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-velocidad_movimiento * Time.deltaTime, 0, 0);
            animator.SetInteger("estado", 1);
            if (!direccion)
            {
                direccion = true;
                sprite.flipX = true;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.position += new Vector3(+velocidad_movimiento * Time.deltaTime, 0, 0);
                animator.SetInteger("estado", 1);
                if (direccion)
                {
                    direccion = false;
                    sprite.flipX = false;
                }
            }
            else
            {

                
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.velocidad_salto = potencia_salto;
            this.transform.position += new Vector3(0, +potencia_salto * Time.deltaTime, 0);
            animator.SetInteger("estado", 3);
        }
    }
}
