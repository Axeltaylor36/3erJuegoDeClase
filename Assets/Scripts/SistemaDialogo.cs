using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //PAT�N SINGLE-TON
    //1. S�lo existe una �nica instacia de SistemaDIalogo
    //2. ES accesible DESDE CUALQUIER PUNTO del programa.

    public static SistemaDialogo sistema;



    //Awake se ejecuta ANTES del Start() independientemente de que 
    //el gameObject est� activo o no

    void Awake()
    {
        //Si el trono est� libre...
        if (sistema ==null)
        {
            //Me hago con el trono, y entonces SistemaDialogo SOY YO (this).
            sistema = this;
        }

        else
        {

            //Me han quitado el trono, por lo tanto, me mato (soy un falso rey)
            Destroy(this.gameObject);

        }
    }

    public void IniciarDialogo(DialogaSO dialogo)
    {



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
