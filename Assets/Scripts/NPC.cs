using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractuable
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private MisionSO miMsision;


    [SerializeField] private DialogaSO dialogo1;

    [SerializeField] private DialogaSO dialogo2;

    private DialogaSO dialogoActual;



    [SerializeField] private float duracionRotacion;

    [SerializeField] private Transform cameraPoint; //punto en el que se pondrá CAMERANPC.

    private void Awake()
    {
        dialogoActual = dialogo1;
    }

    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if (miMsision == misionTerminada)
        {

            dialogoActual = dialogo2;
        }
    }

    public void Interactuar(Transform interactuador)
    {
        //Poco a poco voy rotando hacia el interactuador y CUANDO TERMINE de rotarme... se inicia la interacción
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarDialogo);
    }

    private void IniciarDialogo()
    {
        SistemaDialogo.sistema.IniciarDialogo(dialogoActual, cameraPoint);
    }

    private void OnDisable()
    {
        eventManager.OnTerminarMision -= CambiarDialogo;
    }
}
