using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI texto;
    public GameObject cancelar;
    public GameObject rightButton;
    public GameObject leftButton;
    private string[] textoCompleto;
    int size = 0;
    int current;
    private void Update()
    {
        if (size == 1)
        {
            rightButton.gameObject.SetActive(false);
            leftButton.gameObject.SetActive(false);
        }else if (current == size - 1)
        {
            rightButton.gameObject.SetActive(false);
            leftButton.gameObject.SetActive(true);
        }
        else if(current == 0)
        {
            rightButton.gameObject.SetActive(true);
            leftButton.gameObject.SetActive(false);
        }else
        {
            rightButton.gameObject.SetActive(true);
            leftButton.gameObject.SetActive(true);
        }
    }

    public void SetText (string t, string[] c)
    {
        title.text = t;
        texto.text = c[0];
        textoCompleto = c;
        current = 0;
        size = textoCompleto.Length;
    }
    void SetButtons()
    {
        if(size == 1)
        {
            leftButton.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(false);
        }else
        {
            leftButton.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(true);
        }
    }
    public void Siguiente()
    {
        current++;
        if(current == (size - 1))
        {
            rightButton.gameObject.SetActive(false);
        }
        else
        {
            rightButton.gameObject.SetActive(true);
        }
        texto.text = textoCompleto[current];
    }
    public void Anterior()
    {
        current--;
        if (current == 0)
        {
            leftButton.gameObject.SetActive(false);
        }
        else
        {
            leftButton.gameObject.SetActive(true);
        }
        texto.text = textoCompleto[current];
    }
    public void HiceDancelar()
    {
        cancelar.gameObject.SetActive(false);
    }
    public void ShowCancel()
    {
        cancelar.gameObject.SetActive(true);
    } 
    
}
