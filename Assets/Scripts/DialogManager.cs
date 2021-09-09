using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI texto;
    public GameObject cancelar;
    public GameObject arrowButtons;
    public GameObject lB;
    public GameObject rB;
    private string[] textoCompleto;
    private string[] nombrePestanasCompleto;
    private int pestanasDisponibles = 0;
    int size = 0;
    int current;
    public bool acabo = false;

    public void SetText (string t, string[] c) 
    {
        //  Recibe textos y título
        title.text = t;
        textoCompleto = c;
        //  Define y muestra el texto actual
        current = 0;
        mostrarTexto();
        size = textoCompleto.Length;
        EvaluarCantidad();
        if (size == 1)
        {
            acabo = true;
        }
        else
        {
            acabo = false;
        }
    }

    void EvaluarCantidad()
    {
        if (size == 1)
        {
            arrowButtons.gameObject.SetActive(false);
        }
        else
        {
            arrowButtons.gameObject.SetActive(true);
            ActivarPrimerB();
        }
    }

    void ActivarPrimerB()
    {
        if (current == 0)
        {
            esconderArrow();
            rB.gameObject.SetActive(true);
        }
    }

    void esconderArrow()
    {
        lB.gameObject.SetActive(false);
        rB.gameObject.SetActive(false);
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
    public void Siguiente()
    {
        current++;
        if (current == size - 1)
        {
            acabo = true;
            esconderArrow();
            lB.gameObject.SetActive(true);
        }
        else {
            acabo = false;
            MostrarArrows();
        }
        mostrarTexto();
    }
    public void Anterior()
    {
        current--;
        if (current == 0)
        {
            esconderArrow();
            rB.gameObject.SetActive(true);
        }
        else
        {
            MostrarArrows();
        }
        mostrarTexto();
    }

    void MostrarArrows()
    {
        lB.gameObject.SetActive(true);
        rB.gameObject.SetActive(true);
    }


}
