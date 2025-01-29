using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Misión")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial; //Mensaje inicial.
    public string ordenFinal; //Mensaje victoria.
    public bool tieneRepeticion;
    public int totalRepeticiones;// Veces que tengo que repetir ese paso.
    public int indiceMision; //índice único que representa a cada misión

    [NonSerialized] //PARA QUE EL CAMPO PUEDE RESETEARSE ENTRE PARTIDAS
    public int repeticionActual;


}
