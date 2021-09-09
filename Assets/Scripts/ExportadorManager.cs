using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportadorManager : MonoBehaviour
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

        ResetGoalValues(2);
        dialogPanel.gameObject.SetActive(true);
        dialogPanel.GetComponent<DialogManager>().HiceDancelar();
        dialogPanel.GetComponent<DialogManager>().SetText("Comencemos", new string[] {"El exportador es el comerciante que contacta al productor colombiano y al importador canadiense."
            , "Debe tener registro ICA como exportador y cumplir con la resolución  448/2016."
            , "La solicitud está firmada por una persona Natural o Jurídica."
            , "Los datos de la empresa son: NIT, Razón social, Dirección, Teléfono, E-mail"
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
        gameManagerScript.time +=2;
        gameManagerScript.compileFallasTotal();
        if (fallas == 0)
        {
            tituloFeedback = titulosFeedback[0];
            fallasString = "Tuviste 8 aciertos.\n" + "Hiciste un excelente trabajo, claramente identificas los conceptos mostrados.";
        }
        else if(fallas > 0 && fallas < 4)
        {
            tituloFeedback = titulosFeedback[1];
            fallasString = "Tuviste 8 aciertos.\n" + "Tuviste " + fallas.ToString() + " errores\n\n"
                +"Esto implica un retraso de " + fallas.ToString() + " meses en un proceso que dura 2 meses.\n\n"
                +"El sobrecosto adquirido es: $" + (fallas * 5000000).ToString();
        }
        else if (fallas >= 4)
        {
            tituloFeedback = titulosFeedback[2];
            fallasString = "Tuviste 8 aciertos.\n"+"Tuviste " + fallas.ToString() + " errores\n\n"
                + "Esto implica un retraso de " + fallas.ToString() + " meses en un proceso que dura 2 meses.\n\n"
                + "El sobrecosto adquirido es: $" + (fallas * 5000000).ToString();
        }
        dialogPanel.gameObject.SetActive(true);
        bubbleSpawner.gameObject.SetActive(false);
        globeSpawner.gameObject.SetActive(false);
        dialogPanel.GetComponent<DialogManager>().HiceDancelar();
        dialogPanel.GetComponent<DialogManager>().SetText(tituloFeedback, new string[] {fallasString,
            }
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
            bubbleSpawner.gameObject.SetActive(true);
            bubbleSpawner.GetComponent<BubbleSpawner>().bubbleScale = 1;
        }
        else if(instructionsCounter == 2)
        {
            isBubble = false;
            bubbleSpawner.gameObject.SetActive(false);
            globeSpawner.gameObject.SetActive(true);
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
                instrucciones.GetComponent<Instructions>().SetTexto("¡Vamos por el siguiente reto!");
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
            malDialog.GetComponent<MalDialogManager>().SetTextContent("La resolución ICA 20 de 2016 no existe. Se requiere la 448 de 2016");
        }
        else
        {
            malDialog.gameObject.SetActive(true);
            malDialog.GetComponent<MalDialogManager>().SetTextContent("Fallaste, recuerda los requisitos documentales del Exportador.");
        }
    }
    void PrimeraInstruccion()
    {
        isBubble = true;
        instrucciones.gameObject.SetActive(true);
        instrucciones.GetComponent<Instructions>().SetTexto("El exportador requiere de un registro y una resolución ICA"+"\nEscoge las burbujas correctas.");
    }
    void segundaInstruccion()
    {
        ResetGoalValues(5);
        instrucciones.gameObject.SetActive(true);
        instrucciones.GetComponent<Instructions>().SetTexto("El exportador requiere los siguientes datos:\n" 
            + "\n1. Solicitud firmada\n"
            + "2. Datos de la Empresa\n"
            + "3. Datos del Representante Legal\n"
            + "4. La especie de fruta a exportar\n" 
            + "\nClasifica las cajas a la Derecha o Izquierda según corresponda.");
    }
}
