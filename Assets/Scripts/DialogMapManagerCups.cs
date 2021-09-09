using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogMapManagerCups : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI texto;
    public TextMeshProUGUI estimadoMeses;
    public TextMeshProUGUI copasAcumuladas;
    public GameObject cancelar;
    private string[] textoCompleto;
    int size = 0;
    int current = 0;

    public void SetText(string t, string[] c, int meses, int copas)
    {
        //  Recibe textos y título
        title.text = t;
        textoCompleto = c;
        estimadoMeses.text = meses.ToString() + " Meses";
        copasAcumuladas.text = copas.ToString();
        //  Define y muestra el texto actual
        current = 0;
        mostrarTexto();
        size = textoCompleto.Length;
    }


    public void HiceDancelar()
    {
        cancelar.gameObject.SetActive(false);
    }
    public void ShowCancel()
    {
        cancelar.gameObject.SetActive(true);
    }

    void mostrarTexto()
    {
        texto.text = textoCompleto[current];
    }
}
