using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportadorManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject instrucciones;
    public GameObject malDialog;
    public GameObject bubbleSpawner;
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
        dialogPanel.GetComponent<DialogManager>().SetText("Comencemos", "El exportador es generalmente el empresario que contacta a un productor certificado en Colombia y a un importador canadiense certificado a quien le vende el producto.\n"
            + "Debe de contar con un registro ICA como exportador y la resolución ICA 448/2016\n"
            + "\nLos procesos de certificación tienen una duración dada en meses, cada vez que falles en la prueba, el tiempo aumenta dado que en el proceso real, la certificación se retrasa y eso se ve reflejado en un aumento del costo y tiempo invertido.");
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
        dialogPanel.GetComponent<DialogManager>().SetText("Resumen Exportador", "El Exportador debe de contar con un registro como Exportador ante el ICA, y debe de contar con la resoución 448/2016\n"
            + "El proceso de certificación tarda aaproximadamente 6 meses\n");
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
        else if(instructionsCounter == 2)
        {
            isBubble = false;
            bubbleSpawner.gameObject.SetActive(false);
            bubbleSpawner.GetComponent<BubbleSpawner>().bubbleScale = 1;
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
                //
            }
            instrucciones.gameObject.SetActive(true);
            instrucciones.GetComponent<Instructions>().SetTexto("¡Felicidades, ahora vamos por el siguiente reto!");
            logrados = 0;
        }
    }
    public void Mal(int i)
    {
        if (isBubble)
        {
            malDialog.gameObject.SetActive(true);
            malDialog.GetComponent<MalDialogManager>().SetTextContent("La resolución ICA 20 de 2016 no existe. Se requiere la 448 de 2016");
        }
    }
    void PrimeraInstruccion()
    {
        isBubble = true;
        instrucciones.gameObject.SetActive(true);
        instrucciones.GetComponent<Instructions>().SetTexto("El exportador requiere:\n"+"\n1. Registro Exportador ICA\n"+"2. Resolución ICA 448/2016\n"+"\nEscoge las burbujas corrrectas.");
    }
    void segundaInstruccion()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
