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
    }

    private void EncenderToggleMission(MisionSO mision)
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
