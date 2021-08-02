using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class botonesRespuestaPregunta : MonoBehaviour
{
    public TextMeshProUGUI textoRespuesta;
    public GameObject glossaryGameController;
    public GameObject glossaryManager;
    public void Validar()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>();
        string respuesta = textoRespuesta.text;
        if (glossaryGameController.GetComponent<GlossaryGamePanelController>().palabraCorrecta == respuesta)
        {
            //  Selección correcta
            glossaryManager.GetComponent<GlosarioManager>().Bien();
        }
        else
        {
            //  Selección incorrecta
            glossaryManager.GetComponent<GlosarioManager>().Mal();
        }
    }
}
