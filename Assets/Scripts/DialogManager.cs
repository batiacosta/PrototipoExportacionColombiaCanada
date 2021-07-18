using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI texto;
    public GameObject cancelar;
    public GameObject[] pestanas;
    private string[] textoCompleto;
    private string[] nombrePestanasCompleto;
    private int pestanasDisponibles = 0;
    int size = 0;
    int current;
    private void Update()
    {
    }

    public void SetText (string t, string[] c, string[] nombrePestanas) 
    {
        //  Recibe textos y título
        title.text = t;
        textoCompleto = c;
        nombrePestanasCompleto = nombrePestanas;
        //  Define y muestra el texto actual
        current = 0;
        mostrarTexto();
        size = textoCompleto.Length;
        SetPestanas(size);
    }

    public void SetPestanas(int c)
    {
        //  Define cuantas pestañas van a estar disponibles

        HidePestanas();
        for(int i=0; i < c; i++)
        {
            pestanas[i].gameObject.SetActive(true);
        }
        //  Define como activa la primera pestana
        ElegirPestana(0);
    }

    public void HiceDancelar()
    {
        cancelar.gameObject.SetActive(false);
    }
    public void ShowCancel()
    {
        cancelar.gameObject.SetActive(true);
    }
    void HidePestanas()
    {
        foreach(GameObject p in pestanas)
        {
            p.gameObject.SetActive(false);
        }
    }

    public void ElegirPestana(int currentPestana)
    {
        //  Oscurece las pestanas disponibles no activas
        for (int i = 0; i < size; i++)
        {
            pestanas[i].GetComponent<PestanaProps>().SetColor(false);
            pestanas[i].GetComponent<PestanaProps>().SetNombre(nombrePestanasCompleto[i]);
        }
        //  Aclara el color de la pestana activa
        pestanas[currentPestana].GetComponent<PestanaProps>().SetColor(true);
        current = currentPestana;
        mostrarTexto();
    }
    void mostrarTexto()
    {
        texto.text = textoCompleto[current];
    }
    
}
