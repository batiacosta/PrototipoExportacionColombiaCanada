using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PestanaProps : MonoBehaviour
{

    public int idPestana;
    public Sprite[] images;
    public GameObject dialogMaganer;
    public Text nombre;

    public void SetColor(bool isActive)
    {
        if (isActive)
        {
            this.GetComponent<Button>().image.sprite = images[0];
        }
        else
        {
            this.GetComponent<Button>().image.sprite = images[1];
        }
    }
    public void SetNombre(string n)
    {
        nombre.text = n;
    }
    private void Start()
    {
        
        if (idPestana == 0)
        {
            this.GetComponent<Button>().image.sprite = images[0];
        }
        else
        {
            this.GetComponent<Button>().image.sprite = images[1];
        }
    }



}
