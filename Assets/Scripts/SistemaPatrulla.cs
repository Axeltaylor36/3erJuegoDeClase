
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Enemy main;

    [SerializeField] private Transform ruta;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private float velocidadPatrulla;  


    private List<Vector3> listadoPuntos = new List<Vector3>();

    private int indiceDestinoActual = -1; //Marca el punto ctual al punto al cual debo ir.

    private Vector3 destinoActual;//Marca el destino al cual debo ir

    //Diferencia con array

    private void Awake()//Funciona antes del Start.
    {
        //Le digo al 'main' (Enemy) que el sistema de patrulla soy yo.
        main.Patrulla = this;   
        foreach (Transform punto in ruta)
        {
            //Añado todos los puntos de ruta al listado
            listadoPuntos.Add(punto.position);
        }
    }

    private void OnEnable()
    {
        agent.speed = velocidadPatrulla;
    }
    private void Start()
    {
        StartCoroutine(patrullaYEsperar());
    }
    private IEnumerator patrullaYEsperar()//Corrutina
    {
        //Por siempre.

        while (true)
        {
            CalcularDestino();//Tendré que calcular el nuevo destino
            //Ir a destino.
            agent.SetDestination(destinoActual);
            yield return new WaitUntil( ()  => !agent.pathPending &&  agent.remainingDistance<= 0.2f);//Expresión lambda
            
            yield return new WaitForSeconds(Random.Range(0.25f,3f));
        }
    }

    private void CalcularDestino()
    {
        indiceDestinoActual++;

        //Si nos hemos quedado sin punto...
        if (indiceDestinoActual >= listadoPuntos.Count)
        {
            //Mi destino es dentro del listado de puntos aquel con el nuevo índice calculado
            indiceDestinoActual = 0;
        }

        destinoActual = listadoPuntos[indiceDestinoActual];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StopAllCoroutines();//Abandonamos la corrutina de patrulla.

            //Le decimos al MAIN que active el modo combate

            main.ActivarCombate(other.transform);

        }
    }
}