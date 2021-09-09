using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductorManager : MonoBehaviour
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
        gameManagerScript.SetHiddenLevel(0);

        ResetGoalValues(8);
        dialogPanel.gameObject.SetActive(true);
        dialogPanel.GetComponent<DialogManager>().HiceDancelar();
        dialogPanel.GetComponent<DialogManager>().SetText("Productor", new string[] {"El productor garantiza inocuidad y buenas prácticas agrícolas cumpliendo con requisitos Documentales y de Infraestructura.\n"
            ,"Requerimientos de Infraestructura: \n"
            + "•	Area de Registros\n"
            + "•	Señalización, plano y kit primeros	   auxilios\n"
            + "•	Área de insumos agrícolas\n"
            + "•	Almacén de herramientas\n"
            + "•	Área acopioCosecha\n"
            , "Requerimientos Documentales\n"
            + "•	Solicitud firmada Persona Natural o Jurídica\n"
            + "•	Nombre y contacto Representante Legal\n "
            + "•	Datos del Predio y su ubicación\n"
            + "•	Contrato certificado de Ingeniero Agrónomo y su tarjeta profesional\n"
            + "•	Nombre de especies cultivadas (Gulupa)\n"
            + "•	Datos Empresa."
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
            fallasString = "Tuviste 17 aciertos.\n" + "Hiciste un excelente trabajo, claramente identificas los conceptos mostrados.";
        }
        else if (fallas > 0 && fallas < 4)
        {
            tituloFeedback = titulosFeedback[1];
            fallasString = "Tuviste 17 aciertos.\n"+"Tuviste " + fallas.ToString() + " errores\n\n"
                + "Esto implica un retraso de " + fallas.ToString() + " meses en un proceso que dura 6 meses.\n\n"
                + "El sobrecosto adquirido es: $" + (fallas * 5000000).ToString();
        }
        else if (fallas >= 4)
        {
            tituloFeedback = titulosFeedback[2];
            fallasString = "Tuviste 17 aciertos.\n" + "Tuviste " + fallas.ToString() + " errores\n\n"
                + "Esto implica un retraso de " + fallas.ToString() + " meses en un proceso que dura 6 meses.\n\n"
                + "El sobrecosto adquirido es: $" + (fallas * 5000000).ToString();
        }
       
        dialogPanel.gameObject.SetActive(true);
        bubbleSpawner.gameObject.SetActive(false);
        globeSpawner.gameObject.SetActive(false);
        dialogPanel.GetComponent<DialogManager>().HiceDancelar();
        dialogPanel.GetComponent<DialogManager>().SetText(tituloFeedback, new string[] {fallasString }
        );
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
            isBubble = false;
            globeSpawner.gameObject.SetActive(true);
        }
        else if (instructionsCounter == 2)
        {
            isBubble = true;
            globeSpawner.gameObject.SetActive(false);
            bubbleSpawner.gameObject.SetActive(false);
            segundaInstruccion();
        }
        else if (instructionsCounter == 3)
        {
            ResetGoalValues(7);
            bubbleSpawner.gameObject.SetActive(true);
        }
        else if (instructionsCounter == 4)
        {
            SegundoDialogo();
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
                bubbleSpawner.gameObject.SetActive(false);
                instrucciones.GetComponent<Instructions>().SetTexto("¡Vamos por el siguiente reto!");
                gameManagerScript.enabledLevels = 4;
               
            }
            else
            {
                instrucciones.gameObject.SetActive(true);
                instrucciones.GetComponent<Instructions>().SetTexto("¡Vamos por el siguiente reto!");
                /*gameManagerScript.enabledLevels = 3;
                SegundoDialogo();*/
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
            malDialog.GetComponent<MalDialogManager>().SetTextContent("Es importante que el productor cumpla con las normas de inocuidad, no puede haber Roedores o Material en Descomposición.");
        }
        else
        {
            malDialog.gameObject.SetActive(true);
            malDialog.GetComponent<MalDialogManager>().SetTextContent("La cantidad de cabezas de ganado o número de empleados no son datos relevantes en la documentación.");
        }
    }
    void PrimeraInstruccion()
    {
        isBubble = false;
        instrucciones.gameObject.SetActive(true);
        instrucciones.GetComponent<Instructions>().SetTexto("¿Qué requisitos documentales debe cumplir el productor?:\n" 
            + "\nArrastra los globos según corresponda Falso o Verdadero.");
    }
    void segundaInstruccion()
    {
        ResetGoalValues(5);
        instrucciones.gameObject.SetActive(true);
        instrucciones.GetComponent<Instructions>().SetTexto("¿Qué requerimientos en infraestructura debe cumplir el productor?\n"
            + "\nEscoge las burbujas correctas.");
    }

    // Update is called once per frame

}
