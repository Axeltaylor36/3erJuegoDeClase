using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class SistemaCombate : MonoBehaviour
{

    //Definir una velocidad de combate
    //y poner esta velocidad al agent
    
    [SerializeField] private Enemy main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadCombate;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private Animator anim; 

    private void Awake()
    {
        main.Combate = this;

    }

    //OnEnable: Se ejecuta cuando se activa el script.
    //Se puede ejectuar varias VECES.
    private void OnEnable()
    {
        
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }
    private void Update()
    {
        //Sólo si existe un objetivo...
        if (main.Target != null && agent.CalculatePath(main.Target.position, new NavMeshPath()))
        {
            //Procuraremos que SIEMPRE estemos enfocando al player.
            EnfocarObjetivo();

            //Voy persiguiendo al target entodo momento (calculando su posición)
            agent.SetDestination(main.Target.position);

            //cuando tenga al objetivo a distancia de ataque...
            if (!agent.pathPending && agent.remainingDistance <= distanciaAtaque) 
            {
                anim.SetBool("attacking", true);
            }
            
            

            

        }

        else
        {
            //Deshabilitamos script de combate
            main.ActivarPatrulla();


        }
    }

    private void EnfocarObjetivo()
    {
        //1. Calculo la direccion al objetivo
        Vector3 direccionATarget = (main.Target.transform.position - transform.position).normalized;
        direccionATarget.y = 0; //Pongo la "Y" a 0 para que no se vuelque

        //Transformo una dirección  en una rotación
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);

        //Aplico la rotación.
        transform.rotation = rotacionATarget;
    }

    #region Ejecutados por evento de animación
    private void Atacar()
    {
        //Hacer daño al taraget.
        main.Target.GetComponent<Player>().HacerDanho(danhoAtaque);
    }

    private void FinAnimacionAtaque()
    {
        anim.SetBool("attacking", false);
    }
    #endregion
}
