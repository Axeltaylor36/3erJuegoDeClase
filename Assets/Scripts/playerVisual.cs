using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerVisual : MonoBehaviour
{

    private Animator anim;

    [SerializeField] private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent <Animator>();   

    }

    // Update is called once per frame
    void Update()
    {

        //agent.velocity.magnitude --> Velocidad actual...
        //agent.speed --> Máxima velocidad que tengo configurada

        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);

    }
}
