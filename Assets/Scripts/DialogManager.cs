using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI texto;
    public GameObject cancelar;
    
    public void SetText (string t, string c)
    {
        title.text = t;
        texto.text = c;
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
