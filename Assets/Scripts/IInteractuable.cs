using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

//Interfaz: Es una serie de métodos que se han de implementar
//En aquella entidades que, en este caso, sean interactuables.
public interface IInteractuable 
{
    public void Interactuar(Transform interactor);
}
