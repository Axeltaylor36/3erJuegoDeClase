using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoAnimaciones : MonoBehaviour
{

    [SerializeField]  private NavMeshAgent agent;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //Obtengo mi animator
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizo el par�metro "velocity" en funci�n de la velocidad del agente.
        anim.SetFloat("velocity",agent.velocity.magnitude /agent.speed);
    }
}
