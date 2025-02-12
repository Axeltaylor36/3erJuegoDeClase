using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porton : MonoBehaviour, IInteractuable
{
    [SerializeField] private MisionSO mision;
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] TMP_Text mensaje;

    public void Interactuar(Transform interactor)
    {
        if (mision.repeticionActual >= mision.totalRepeticiones)
        {
            SceneManager.LoadScene(2);
        }
    }
    private void OnMouseEnter()
    {
        if (mision.repeticionActual < mision.totalRepeticiones)
        {
            Debug.Log("Necesitas Setas");
            mensaje.text = "Necesitas completar la mision de Mr Fernando";
        }

        else 
        {

            Debug.Log("Funciona");
            mensaje.text = "Click para salir de la mazmorra";

        }
        mensaje.enabled = true;
    }
    private void OnMouseExit()
    {
        mensaje.enabled = false;
    }
}
