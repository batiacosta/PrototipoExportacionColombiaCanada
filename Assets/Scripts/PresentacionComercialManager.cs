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
        dialogPanel.GetComponent<DialogManager>().SetText("Presentación Comercial", new string[] { "La gulupa debe de estar en una caja que debe de contener los datos que permitan dar una trazabilidad. Los datos son la fecha de producción, lote, fecha de caducidad, número del establecimiento, el peso del producto, el código del predio y el registro de la planta empacadora, pues ésta debe de estar también certificada." });
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
        //gameManagerScript.time += 6;
        dialogPanel.gameObject.SetActive(true);
        dialogPanel.GetComponent<DialogManager>().HiceDancelar();
        dialogPanel.GetComponent<DialogManager>().SetText("¡Muy bien!", new string[] {"La presentación comercial cuenta con:\n"
            + "\n1. Peso en Kg\n"
            + "2. Fecha de producción\n"
            + "3. Número del establecimiento\n"
            + "4. Fecha de Caducidad\n"
            + "5. Código del predio\n"
            + "6. Registro Empacadora"
            , "\nAcabas de activar un nuevo módulo" });
    }

    public void CerrarImagen()
    {
        cajaImagen.gameObject.SetActive(false);
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
            gameManagerScript.enabledLevels = 6;
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
        gameManagerScript.time += 1;
        if (isBubble)
        {
            malDialog.gameObject.SetActive(true);
            malDialog.GetComponent<MalDialogManager>().SetTextContent("El color y el tamaño son irrelevantes, siempre y cuando se tenga la trazabilidad del producto");
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
