using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvioManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject instrucciones;
    public GameObject malDialog;
    public GameObject bubbleSpawner;
    public GameObject globeSpawner;
    private GameManager gameManagerScript;
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
        globeSpawner.gameObject.SetActive(false);
        malDialog.gameObject.SetActive(false);
        instructionsCounter = 0;
        PrimerDialogo();
    }
    void PrimerDialogo()
    {
        isBubble = true;
        gameManagerScript.SetHiddenLevel(0);
        ResetGoalValues(1);
        dialogPanel.gameObject.SetActive(true);
        dialogPanel.GetComponent<DialogManager>().HiceDancelar();
        dialogPanel.GetComponent<DialogManager>().SetText("Proceso de Envío", new string[] { 
            "El proceso de envío de la gulupa es por vía aérea, este envío debe de contar con una factura donde se encuentren los datos verificables tanto del exportador, como del importador."
            ,"El exportador requiere los siguientes datos:\n"
            + "\n1. Solicitud firmada por persona Natural o Jurídica\n"
            + "2. Datos de la Empresa: NIT, Razón Social, Dirección, Teléfono y E-mail\n"
            + "3. Datos del Representante Legal: Nombre, Datos de contacto\n"
            + "4. Nombre de las especies a exportar\n"
            , "El transporte de la Gulupa hacia Canadá debe de realizarse ÚNICAMENTE por vía aérea",
            "El proceso del envío de no cumplir los requisitos implicará la pérdida de la mercancía, de modo que perderás dinero y tiempo mientras se realizan nuevamente los trámites y certificados que correspondan"
        });
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
        gameManagerScript.time += 1;
        gameManagerScript.compileFallasTotal();
        if (fallas == 0)
        {
            tituloFeedback = titulosFeedback[0];
            fallasString = "Hiciste un excelente trabajo, claramente identificas los siguientes conceptos... ";
        }
        else if (fallas > 0 && fallas < 4)
        {
            tituloFeedback = titulosFeedback[1];
            fallasString = "Tuviste " + fallas.ToString() + " errores, esto implica un retraso de " + fallas.ToString() + " meses en un proceso que dura 1 mese, y una pérdida de $" + (fallas * 5000000).ToString();
        }
        else if (fallas >= 4)
        {
            tituloFeedback = titulosFeedback[2];
            fallasString = "Tuviste " + fallas.ToString() + " errores, esto implica un retraso de " + fallas.ToString() + " meses en un proceso que dura 1 mese, y una pérdida de $" + (fallas * 5000000).ToString();
        }
        dialogPanel.gameObject.SetActive(true);
        bubbleSpawner.gameObject.SetActive(false);
        globeSpawner.gameObject.SetActive(false);
        dialogPanel.GetComponent<DialogManager>().HiceDancelar();
        dialogPanel.GetComponent<DialogManager>().SetText(tituloFeedback, new string[] { fallasString, "El exportador requiere los siguientes datos:\n"
            , "\n1. Solicitud firmada por persona Natural o Jurídica\n"
            , "2. Datos de la Empresa: NIT, Razón Social, Dirección, Teléfono y E-mail\n"
            , "3. Datos del Representante Legal: Nombre, Datos de contacto\n"
            , "4. Nombre de las especies a exportar\n"
            , "\nAcabas de activar un nuevo módulo" });
    }

    public void CloseDialog()
    {
        counterDialog++;
        dialogPanel.gameObject.SetActive(false);
        if (counterDialog == 1)
        {
            PrimeraInstruccion();
        }
        if (counterDialog == 2)
        {
            gameManagerScript.enabledLevels = 7;
            gameManagerScript.ChangeScene("Progreso");
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
            globeSpawner.gameObject.SetActive(true);
            ResetGoalValues(5);
            segundaInstruccion();
        }
        else if (instructionsCounter == 3)
        {
            globeSpawner.gameObject.SetActive(true);
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
                instrucciones.gameObject.SetActive(true);
                instrucciones.GetComponent<Instructions>().SetTexto("¡Felicidades, ahora vamos por el siguiente reto!");
            }
            else
            {
                gameManagerScript.enabledLevels = 3;
                SegundoDialogo();
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
            malDialog.GetComponent<MalDialogManager>().SetTextContent("Unicamente se deben de enviar las Gulupas por vía aérea");
        }
        else
        {
            malDialog.GetComponent<MalDialogManager>().SetTextContent("El nombre de la finca o el Certificado de buenas prácticas agrícolas no son requeridos en la factura.");
        }
    }
    void PrimeraInstruccion()
    {
        isBubble = true;
        instrucciones.gameObject.SetActive(true);
        instrucciones.GetComponent<Instructions>().SetTexto("El proceso de envío debe de ser por vía Aérea.\n" + "\nEscoge las burbujas corrrectas.");
    }
    void segundaInstruccion()
    {
        ResetGoalValues(3);
        instrucciones.gameObject.SetActive(true);
        instrucciones.GetComponent<Instructions>().SetTexto("Los datos que debe de tener la factura son:\n"
            + "\nArrastra los globos hacia el lado que corresponda.");
    }
}
