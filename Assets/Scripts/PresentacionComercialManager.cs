using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentacionComercialManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject instrucciones;
    public GameObject malDialog;
    public GameObject bubbleSpawner;
    private GameManager gameManagerScript;
    public GameObject cajaImagen;
    public int total;
    public int logrados;
    int counterDialog = 0;
    int instructionsCounter = 0;
    bool isBubble = false;

    int fallas = 0;
    string fallasString = "";
    string[] titulosFeedback = new string[] { "¡Muy bien!", "Buen intento", "Ten cuidado" };
    string tituloFeedback;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        counterDialog = 0;
        instrucciones.gameObject.SetActive(false);
        bubbleSpawner.gameObject.SetActive(false);
        malDialog.gameObject.SetActive(false);
        instructionsCounter = 0;
        PrimerDialogo();
    }
    void PrimerDialogo()
    {
        gameManagerScript.SetHiddenLevel(0);

        ResetGoalValues(6);
        dialogPanel.gameObject.SetActive(true);
        dialogPanel.GetComponent<DialogManager>().HiceDancelar();
        dialogPanel.GetComponent<DialogManager>().SetText("Presentación Comercial", new string[] { "El empaque de la Gulupa es una caja de cartón con bolsa plástica. Dicho empaque contiene datos que permiten dar trazabilidad al producto."
            , "Datos del empaque:\n\n"
            + "•	Fecha de producción.\n"
            + "•	Lote.\n"
            + "•	Fecha de caducidad.\n"
            + "•	Número del establecimiento.\n"
            + "•	Peso del producto.\n"
            + "•	Código del predio.\n"
            + "•	Registro certificado ICA de planta empacadora."
        }
        );
    }

    public void ResetGoalValues(int t)
    {
        total = t;
        logrados = 0;
        gameManagerScript.ResetTotal(t);
    }
    void SegundoDialogo()
    {
        gameManagerScript.SetHiddenLevel(0);
        gameManagerScript.time += 6;
        gameManagerScript.compileFallasTotal();

        if (fallas == 0)
        {
            tituloFeedback = titulosFeedback[0];
            fallasString = "Tuviste 8 aciertos.\n" + "Hiciste un excelente trabajo, claramente identificas los conceptos mostrados.";
        }
        else if (fallas > 0 && fallas < 4)
        {
            tituloFeedback = titulosFeedback[1];
            fallasString = "Tuviste 8 aciertos.\n" + "Tuviste " + fallas.ToString() + " errores\n\n"
                + "Esto implica un retraso de " + fallas.ToString() + " meses en un proceso que dura 6 meses.\n\n"
                + "El sobrecosto adquirido es: $" + (fallas * 5000000).ToString();
        }
        else if (fallas >= 4)
        {
            tituloFeedback = titulosFeedback[2];
            fallasString = "Tuviste 8 aciertos.\n" + "Tuviste " + fallas.ToString() + " errores\n\n"
                + "Esto implica un retraso de " + fallas.ToString() + " meses en un proceso que dura 6 meses.\n\n"
                + "El sobrecosto adquirido es: $" + (fallas * 5000000).ToString();
        }

       
        dialogPanel.gameObject.SetActive(true);
        bubbleSpawner.gameObject.SetActive(false);
        dialogPanel.GetComponent<DialogManager>().HiceDancelar();
        dialogPanel.GetComponent<DialogManager>().SetText(tituloFeedback, new string[] {fallasString }
        );
    }

    public void CerrarImagen()
    {
        cajaImagen.gameObject.SetActive(false);
    }

    public void CloseDialog()
    {
        if (dialogPanel.GetComponent<DialogManager>().acabo == true)
        {
            counterDialog++;
            dialogPanel.gameObject.SetActive(false);
            if (counterDialog == 1)
            {
                PrimeraInstruccion();
            }
            else if (counterDialog == 2)
            {
                gameManagerScript.enabledLevels = 6;
                gameManagerScript.ChangeScene("Progreso");
            }
        }
        else
        {
            dialogPanel.GetComponent<DialogManager>().Siguiente();
        }
    }

    public void CloseInstructions()
    {
        instructionsCounter++;
        instrucciones.gameObject.SetActive(false);
        if (instructionsCounter == 1)
        {
            bubbleSpawner.gameObject.SetActive(true);
            bubbleSpawner.GetComponent<BubbleSpawner>().bubbleScale = 1;
        }
        else if (instructionsCounter == 2)
        {
            isBubble = false;
            bubbleSpawner.gameObject.SetActive(false);
            //segundaInstruccion();
        }
        else if (instructionsCounter == 3)
        {
        }
    }
    public void CloseMal()
    {
        malDialog.gameObject.SetActive(false);
    }
    public void Bien()
    {
        logrados = logrados + 1;
        if (logrados == total)
        {
            if (isBubble)
            {
                //instrucciones.gameObject.SetActive(true);
                SegundoDialogo();
                cajaImagen.gameObject.SetActive(true);
            }
            else
            {
                gameManagerScript.enabledLevels = 6;
                SegundoDialogo();
                cajaImagen.gameObject.SetActive(true);
            }

            logrados = 0;
        }
    }
    public void Mal(int i)
    {
        fallas++;
        gameManagerScript.addFallasLocal();
        gameManagerScript.time += 1;
        if (isBubble)
        {
            malDialog.gameObject.SetActive(true);
            malDialog.GetComponent<MalDialogManager>().SetTextContent("El color de la caja es irrelevante, siempre y cuando se tenga la trazabilidad del producto");
        }
        else
        {
            malDialog.GetComponent<MalDialogManager>().SetTextContent("El número de empleados no es un dato requerido");
        }
    }
    void PrimeraInstruccion()
    {
        isBubble = true;
        instrucciones.gameObject.SetActive(true);
        instrucciones.GetComponent<Instructions>().SetTexto("La presentación comercial debe tener:\n" 
            + "\n1. Peso en Kg\n" 
            + "2. Fecha de producción\n"
            + "3. Número del establecimiento\n"
            + "4. Fecha de Caducidad\n"
            + "5. Código del predio\n"
            + "6. Registro Empacadora\n"
            + "\nEscoge las burbujas corrrectas.");
    }
    void segundaInstruccion()
    {
        ResetGoalValues(5);
        instrucciones.gameObject.SetActive(true);
        instrucciones.GetComponent<Instructions>().SetTexto("El exportador requiere los siguientes datos:\n"
            + "\n1. Solicitud firmada por persona Natural o Jurídica\n"
            + "2. Datos de la Empresa: NIT, Razón Social, Dirección, Teléfono y E-mail\n"
            + "3. Datos del Representante Legal: Nombre, Datos de contacto\n"
            + "4. Nombre de las especies a exportar\n"
            + "\nEscoge las burbujas corrrectas.");
    }
}
