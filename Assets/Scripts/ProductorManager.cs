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
        dialogPanel.GetComponent<DialogManager>().SetText("Requisitos Productor", new string[] {"El productor debe de cumplir con unos requerimientos que son Requisitos Documentales y Requisitos de Infraestructura que garantizan y certifican inocuidad, buenas prácticas agrícolas y manejo de residuos entre otros.\n"
            , "En este módulo se mencionan algunos de esos requisitos que irán clasificados en Documentales y de Infraestructura\n"
            ,"El productor debe cumplir en su Infraestructura con:\n"
            + "\nArea de Registros, " + "Señalización, "
            + "Area de insumos agrícolas, " + "Almacen de herramientas, "
            + "Area acopioCosecha\n"
            + "Plano \n"
            + "Kit Primeros Auxilios. \n\n"
            , "El productor debe cumplir en su Documentación con:\n"
            + "\nSolicitud firmada Persona Natural o Jurídica, \n"
            + "Nombre y contacto Representante Legal\n "
            + "Datos del Predio y su ubicación\n "
            + "Contrato certificado de Ingeniero Agrónomo y su tarjeta profesional\n "
            + "Nombre de especies cultivadas\n"
            + "Datos Empresa."
            , "\nLos procesos de certificación tienen una duración, cada vez que falles en la prueba, el tiempo aumenta dado que en el proceso real, la certificación se retrasa y eso se ve reflejado en un aumento del costo y tiempo invertido." });
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
        dialogPanel.gameObject.SetActive(true);
        dialogPanel.GetComponent<DialogManager>().HiceDancelar();
        dialogPanel.GetComponent<DialogManager>().SetText("¡Muy bien!", new string[] {"El productor debe cumplir en su Infraestructura con:\n"
            + "\nArea de Registros, " + "Señalización, "
            + "Area de insumos agrícolas, " + "Almacen de herramientas, "
            + "Area acopioCosecha, "+ "Plano, "
            + "Kit Primeros Auxilios. \n\n"
            , "El productor debe cumplir en su Documentación con:\n"
            + "\nSolicitud firmada Persona Natural o Jurídica, \n"
            + "Nombre y contacto Representante Legal, "
            + "Datos del Predio y su ubicación, "
            + "Contrato certificado de Ingeniero Agrónomo y su tarjeta profesional, "
            + "Nombre de especies cultivadas, "
            + "Datos Empresa.\n\n"
            , "\n¡Acabas de activar un nuevo Módulo!" });
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
            gameManagerScript.time += 6;
            gameManagerScript.ChangeScene("Progreso");
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
                instrucciones.GetComponent<Instructions>().SetTexto("¡Felicidades, ahora vamos por el siguiente reto!");
                gameManagerScript.enabledLevels = 4;
               
            }
            else
            {
                instrucciones.gameObject.SetActive(true);
                instrucciones.GetComponent<Instructions>().SetTexto("¡Felicidades, ahora vamos por el siguiente reto!");
                /*gameManagerScript.enabledLevels = 3;
                SegundoDialogo();*/
            }

            logrados = 0;
        }
    }
    public void Mal(int i)
    {
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
        instrucciones.GetComponent<Instructions>().SetTexto("¿Qué requisitos documentales debe cunmplir el productor?:\n" 
            + "\nSolicitudes, datos de la empresa, "
            + "datos del predio, "
            + "contrato certificado de Ingeniero Agrónomo y su tarjeta profesional, "
            + "nombre de especies cultivadas.\n"
            + "\nArrastra los globos segun corresponda Falso o Verdadero.");
    }
    void segundaInstruccion()
    {
        ResetGoalValues(5);
        instrucciones.gameObject.SetActive(true);
        instrucciones.GetComponent<Instructions>().SetTexto("¿Qué requerimientos en infraestructura debe cumplir el productor?\n"
           + "Areas y señalizaciones, planos y Kit de primeros auxilios."
            + "\n"
            + "\nEscoge las burbujas corrrectas.");
    }

    // Update is called once per frame

}
