using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessBot : MonoBehaviour
{
    [SerializeField] private Player player;

    private Vector3 distanciaPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //Calculo la distancia inicial que hay entre el player y yo (cámara)
        distanciaPlayer = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + distanciaPlayer;   
    }
}
