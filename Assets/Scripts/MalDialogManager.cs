using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MalDialogManager : MonoBehaviour
{
    public TextMeshProUGUI textContent;
    // Start is called before the first frame update
    public void SetTextContent(string txt)
    {
        textContent.text = txt;
    }
}
