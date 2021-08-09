using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string link;
    public Text texto;
    private void Start()
    {
        texto.text = link;
    }
    public void goToLink()
    {
        Application.OpenURL(link);
    }
    
}
