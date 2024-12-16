using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogaSO miDialogo;
    [SerializeField] private float duracionRotacion;

    [SerializeField] private Transform cameraPoint; //punto en el que se pondrá CAMERANPC.
    public void Interactuar(Transform interactuador)
    {
        //Poco a poco voy rotando hacia el interactuador y CUANDO TERMINE de rotarme... se inicia la interacción
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }

    private void IniciarInteraccion()
    {
        SistemaDialogo.sistema.IniciarDialogo(miDialogo, cameraPoint);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
