using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Misi�n")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial; //Mensaje inicial.
    public string ordenFinal; //Mensaje victoria.
    public bool tieneRepeticion;
    public int totalRepeticiones;// Veces que tengo que repetir ese paso.
    public int indiceMision; //�ndice �nico que representa a cada misi�n

    [NonSerialized] //PARA QUE EL CAMPO PUEDE RESETEARSE ENTRE PARTIDAS
    public int repeticionActual;


}
