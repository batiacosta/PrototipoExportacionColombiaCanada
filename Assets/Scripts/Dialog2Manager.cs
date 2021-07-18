using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog2Manager : MonoBehaviour
{
    public Color32 fondoPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().color = fondoPanel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
