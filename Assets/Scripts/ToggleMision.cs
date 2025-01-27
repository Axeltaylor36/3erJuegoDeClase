using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToggleMision : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoMision;

    private Toggle toggleVisual;

    public Toggle ToggleVisual { get => toggleVisual; }
    public TMP_Text TextoMision { get => textoMision; }

    private void Awake()
    {
        toggleVisual = GetComponent<Toggle>();
    }
}
