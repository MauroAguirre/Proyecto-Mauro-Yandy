using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_controles : MonoBehaviour
{
    public bool direccion = true;
    public float velocidad_movimiento = 5f;
    public float potencia_salto = 60f;
    private Animator animator;
    private SpriteRenderer sprite;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (animator.GetInteger("estado"))
        {
            case 0:
            case 1:
                animator.SetInteger("estado", 0);
                //ataque
                if (Input.GetKey(KeyCode.G))
                {
                    animator.SetInteger("estado", 2);
                    Invoke("terminaAtaque", 1);
                }
                else
                {
                    //movimiento
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
                //saltar
                if (Input.GetKey(KeyCode.W))
                {
                    this.transform.position += new Vector3(0, +potencia_salto * Time.deltaTime, 0);
                    animator.SetInteger("estado", 2);
                    Invoke("terminaAtaque", 1); ;
                }
                break;
            case 2:
                break;
        }
        
    }
    public void terminaAtaque()
    {
        animator.SetInteger("estado",0);
    }
}
