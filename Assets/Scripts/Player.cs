using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    private Camera cam;
    private NavMeshAgent agent;

    //Almaceno el último transform que clické con el ratón.
    private Transform LastClick;
 
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            Movement();
        }
        ComprobarInteraccion();

    }


    private void Movement()
    {
        //Si clicko con el mouse izq.
        if (Input.GetMouseButtonDown(0))
        {
            //Creo un rayo desde la cámara a la posicion del ratón.
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //Y si ese rayo impacta en algo
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //Le decimos al agente (nosotros) que tiene como destino al punto de impacto.
                agent.SetDestination(hitInfo.point);

                //Actualizo el últimoHit con el transform que acabo de clickar.
                LastClick = hitInfo.transform;
            }
        }
    }
    private void ComprobarInteraccion()
    {
        //Si existe un interactuable al cual clické y lleva consigo el script NPC...
        if (LastClick != null && LastClick.TryGetComponent(out NPC npc))
        {
            //Actualizo distancia de parada para no "Comerme" al NPC.
            agent.stoppingDistance = 3f;

            //Mira a ver si hemos llegado a dicho destino.
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                //Y por lo tanto, interactuo con el NPC. Ponemos el THIS para dejar claro que es NUESTRO transform.
                npc.Interactuar(this.transform);

                //Me olvido de cual fue el ultimo click, porque sólo quiero interactuar UNA VEZ.
                //Si lo dejamos interactuaremos todo el timepo con el NPC
                LastClick = null;
            }
        }

        //Si no es un NPC, si no que es un clik al suelo...
        else if (LastClick)
        {
            //Reseteo el stoppingDistance original.
            agent.stoppingDistance = 0f;
        }
        
    }

    public void HacerDanho(float danhoAtaque)
    {
        Debug.Log("PUTOOOOOOOOOOO, NO ME ANDES PICOTANDO" + danhoAtaque);
    }
}
