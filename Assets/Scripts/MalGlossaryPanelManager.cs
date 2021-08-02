using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MalGlossaryPanelManager : MonoBehaviour
{
    public TextMeshProUGUI pregunta;
    public TextMeshProUGUI respuesta;
    public GameObject glossaryManager;
    // Start is called before the first frame update
    public void SetFeedback(string p, string r) {
        pregunta.text = p;
        respuesta.text = r;
    }
    public void Continuar() {
        //   Cuando se de click en continuar, se debe enviar la petición al Manager.
        glossaryManager.GetComponent<GlosarioManager>().CerrarPanelMal();
    }
}
