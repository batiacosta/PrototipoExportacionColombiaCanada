﻿using System.Collections;
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
        dialogPanel.GetComponent<DialogManager>().SetText("Comencemos", new string[] {"El exportador es generalmente el empresario que contacta a un productor certificado en Colombia y a un importador canadiense certificado a quien le vende el producto.\n"
            , "Debe tener el registro ICA como exportador y cumplir con la resolución ICA 448/2006.\n"
            , "Solicitud firmada por persona Natural o Jurídica\n"
            , "Datos de la Empresa: NIT, Razón Social, Dirección, Teléfono y E-mail\n"
            , "Datos del Representante Legal: Nombre, Datos de contacto\n"
            , "Nombre de la especie a exportar (Gulupa)\n"
            , "\nLos procesos de certificación tienen una duración dada en meses, cada vez que falles en la prueba, el tiempo aumenta dado que en el proceso real, la certificación se retrasa y eso se ve reflejado en un aumento del costo y tiempo invertido." });
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
        gameManagerScript.time +=6;
        dialogPanel.gameObject.SetActive(true);
        bubbleSpawner.gameObject.SetActive(false);
        globeSpawner.gameObject.SetActive(false);
        dialogPanel.GetComponent<DialogManager>().HiceDancelar();
        dialogPanel.GetComponent<DialogManager>().SetText("¡Muy bien!", new string[] {"El exportador requiere los siguientes datos:\n"
            + "\n1. Solicitud firmada por persona Natural o Jurídica\n"
            + "2. Datos de la Empresa: NIT, Razón Social, Dirección, Teléfono y E-mail\n"
            + "3. Datos del Representante Legal: Nombre, Datos de contacto\n"
            + "4. Nombre de la especie a exportar (Gulupa)\n"
            , "Es muy importante saber que debe de contar con un registro ICA como exportador y la resolución ICA 448/2006\n"
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
        gameManagerScript.time += 1;
        if (isBubble)
        {
            malDialog.gameObject.SetActive(true);
            malDialog.GetComponent<MalDialogManager>().SetTextContent("La resolución ICA 20 de 2016 no existe. Se requiere la 448 de 2016");
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
        instrucciones.GetComponent<Instructions>().SetTexto("El exportador requiere de un registro y una resolución ICA"+"\nEscoge las burbujas corrrectas.");
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
            + "\nEscoge las burbujas corrrectas.");
    }
}
