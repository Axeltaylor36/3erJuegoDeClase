using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;


    private List<Transform> listadoPuntos = new List<Transform>();


    //Diferencia con array

    private Transform[] array = new Transform[0];

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform punto in ruta)
        {
            Debug.Log(punto.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
