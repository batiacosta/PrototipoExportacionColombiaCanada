using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CopaPanelManager : MonoBehaviour
{
    public TextMeshProUGUI realimentacion;
    public GameObject glossaryManager;
    public string[] bancoRealimentaciones = {
        "Lograste bono de 1 mes para Exportador",
        "Lograste bono de 1 mes para Presentación Comercial",
        "Lograste bono de 1 mes para Exportador",
        "Lograste bono de 1 mes para Productor"
    };

    public void setRealimentacion(int elegido)
    {
        realimentacion.text = bancoRealimentaciones[elegido];
    }
    public void continuar()
    {
        glossaryManager.GetComponent<GlosarioManager>().continuarPanelCopa();
    }
}
