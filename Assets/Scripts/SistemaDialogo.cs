using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    [SerializeField] private GameObject marcoDialogo; //Marco a habilitar/deshabilitar

    [SerializeField] private TMP_Text textoDialogo; //El texto donde se verán reflejados los diálogos.

    [SerializeField] private Transform npcCamera; //Cámara compartida por todos los NPCs.


    private bool escribiendo;
    private int indiceFraseActual = 0;

    private DialogaSO dialogoActual; //Para saber en todo momento cuál es el diálogo con el que estamos trabajando



    //PATRÓN SINGLE-TON
    //1. Sólo existe una única instacia de SistemaDIalogo
    //2. ES accesible DESDE CUALQUIER PUNTO del programa.

    public static SistemaDialogo sistema;



    //Awake se ejecuta ANTES del Start() independientemente de que 
    //el gameObject esté activo o no

    void Awake()
    {
        //Si el trono está libre...
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

    public void IniciarDialogo(DialogaSO dialogo, Transform cameraPoint)
    {
        Time.timeScale = 0;
        //El diálogo actual que tenemos que tratar es el que me pasan por parámetro.
        dialogoActual = dialogo;
        marcoDialogo.SetActive(true);

        //Posiciono y roto la cámara en el punto de este NPC.
        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);

        StartCoroutine(EscribirFrase());
    }
    // Se escribe la frase poco a poco.
    private IEnumerator EscribirFrase()
    {
        escribiendo = true;

        //Limpio el texto.
        textoDialogo.text = string.Empty;

        //ToCharArray = Desmenuzo la frase actual por caracteres por separado.
        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();


        foreach (char letra in  fraseEnLetras)
        {
            //1.Incluir la letra en el texto
            textoDialogo.text += letra;

            //WaitForSecondsRealtime: no se para si el tiempo está congelado.
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }

        escribiendo = false;
    }
    //Una vez le das a un boton en medio de la escritura se escribe automaticamente todo repentinamente.
    private void CompletarFrase()
    {
        //Si me piden completar la frase entera, en el texto pongo la frase entera.
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        
        
        //PARO LAS CORRUTINAS QUE ESTÉN FUNCIONANDO EN EL MOMENTO
        StopAllCoroutines();

        escribiendo = false;
    }
    //Se ejecuta al hacer click al botón para pasar a la siguiente frase.
    public void SiguienteFrase()
    {
        if (!escribiendo) 
        {

            indiceFraseActual++; //Entonces, avanzo a la siguiente frase.

            //Si aún me quedan frases por sacar...
            if(indiceFraseActual < dialogoActual.frases.Length)
            { 
                StartCoroutine(EscribirFrase());
            }
            else
            {
                FinalizarDialogo();
            }
        
        }

        else
        {

            CompletarFrase();
        }


    }

    private void FinalizarDialogo()
    {
        Time.timeScale = 1;
        
        marcoDialogo.SetActive(false);//Cerramos el marco de diálogo.
        indiceFraseActual = 0; //Para que ene posteriores diálogos empezamos desde índice 0.
        escribiendo = false ;

        dialogoActual = null;


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
