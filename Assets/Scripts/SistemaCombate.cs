using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{

    //Definir una velocidad de combate
    //y poner esta velocidad al agent
    
    [SerializeField] private Enemy main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadCombate;

    private void Awake()
    {
        main.Combate = this;

    }

    //OnEnable: Se ejecuta cuando se activa el script.
    //Se puede ejectuar varias VECES.
    private void OnEnable()
    {
        main.Combate = this;
    }
    private void Update()
    {
        agent.speed = velocidadCombate;

        //Voy persiguiendo al target entodo momento (calculando su posición)
        agent.SetDestination(main.Target.position);
    }
}
