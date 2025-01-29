using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField]
    private EventManagerSO eventManager;

    [SerializeField]
    private ToggleMision[] togglesMision;//Coleccion de toggles.
    // Start is called before the first frame update

    private void OnEnable()
    {
        //Me suscribo al evento y lo vinculo con el método.
        eventManager.OnNuevaMision += EncenderToggleMission;
        eventManager.OnActualizarMision += ActualizarToggleMision;
        eventManager.OnActualizarMision += TerminarToggleMision;
    }

    private void EncenderToggleMission(MisionSO mision)
    {
        //Alientamos el texto con el contenido de la misión
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;

        //y si tiene repetición...
        if (mision.tieneRepeticion)
        {

            togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
        }

        togglesMision[mision.indiceMision].gameObject.SetActive(true); //Enciende el toggle para que se vea en la pantalla


    }
    private void ActualizarToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";

    }

    private void TerminarToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].ToggleVisual.isOn = true; //Al termianr la mision "chekeamos" el toggle.
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenFinal; //ponemos el texto de victoria.
    }

}
