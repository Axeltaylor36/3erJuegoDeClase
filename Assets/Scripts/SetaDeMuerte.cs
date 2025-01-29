using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaDeMuerte : MonoBehaviour, IInteractuable
{
    private Outline outline;

    [SerializeField] private MisionSO mision;
    [SerializeField] private EventManagerSO eventManager;

    private void Awake()
    {
        outline = GetComponent<Outline>();

    }

    public void Interactuar(Transform interactor)
    {
        mision.repeticionActual++; //Aumentamos en uno la repeticion de esta mision.

        //Todavua qyedab setas por recoger.
        if (mision.repeticionActual < mision.totalRepeticiones)
        {
            eventManager.ActualizarMision(mision);

        }
        else//Ya hemos terminado de rcoger las setas
        {
        eventManager.ActualizarMision(mision);

        }
        Destroy(gameObject);
    }

    private void OnMouseEnter()
    {
       outline.enabled = true; 
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
