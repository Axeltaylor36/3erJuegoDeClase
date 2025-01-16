using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractuable
{

    private SistemaPatrulla patrulla;
    private SistemaCombate combate;

    private Transform target;

    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public Transform Target { get => target; set => target = value; }

    public void ActivarCombate(Transform target)
    {
        patrulla.enabled = false;//Desactivamos patrulla
        combate.enabled = true;//Activamos combate
        this.Target = target;//Definimos target.
    }

    public void ActivarPatrulla()
    {
        combate.enabled = false;
        patrulla.enabled = true;    
    }

    public void Interacruar()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //Empieza el juego y activamos la patrulla.
        patrulla.enabled = true ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
