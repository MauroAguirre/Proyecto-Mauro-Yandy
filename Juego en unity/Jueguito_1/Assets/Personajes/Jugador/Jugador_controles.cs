using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_controles : MonoBehaviour
{
    public float velocidad_movimiento = 5f;
    public float velocidad_salto = 5f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (animator.GetInteger("estado"))
        {
            case 0:
            case 1:
                if (Input.GetKey(KeyCode.A))
                {
                    this.transform.position += new Vector3(-velocidad_movimiento * Time.deltaTime, 0, 0);
                    animator.SetInteger("estado", 1);
                }
                else
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        this.transform.position += new Vector3(+velocidad_movimiento * Time.deltaTime, 0, 0);
                        animator.SetInteger("estado", 1);
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.G)||(Input.GetKey(KeyCode.G)&& Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A)))
                        {
                            animator.SetInteger("estado", 2);
                        }
                        else
                        {
                            animator.SetInteger("estado", 0);
                        }
                    }
                }
                break;
            case 2:
                break;
        }
        
    }
    public void terminaAtaque()
    {
        animator.SetInteger("estado",0);
        //animator.state
    }
}
