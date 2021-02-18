using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Sprite[] status;
    public GameObject[] stages;
    public GameObject dialogPanel;
    public GameObject instructions;
    public GameObject playerDialog;
    public GameObject finalScreen;
    private GameManager gameManagerScript;
    private GameObject gameManager;
    public int currentStage;
    private DialogManager dialogoScript;
    public int progress;
    int isReadyForALevel=0;
    // Start is called before the first frame update
    void Start()
    {
        finalScreen.gameObject.SetActive(false);
        playerDialog.gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript.isFirstTime)
        {
            gameManagerScript.UpdateMoneyValue(10000);
            gameManagerScript.UpdateTimeValue(1);
            gameManagerScript.isFirstTime = false;
        }
        gameManagerScript.SetHiddenLevel(3);
        progress = gameManagerScript.enabledLevels;
        if(progress == 2)
        {
            PrimeraVez();
        }
        UpdateProgressStatus(progress);
    }
    public void ChangeScene()
    {
        string sceneName;
        Debug.Log(currentStage);
        playerDialog.gameObject.SetActive(false);
        if (currentStage == 2)
        {
            
            sceneName = "Exportador";
            gameManagerScript.ChangeScene(sceneName);
        }
        else if (currentStage == 3)
        {
            sceneName = "Productor";
            gameManagerScript.ChangeScene(sceneName);
        }
        else if (currentStage == 4)
        {
            sceneName = "Importador";
            gameManagerScript.ChangeScene(sceneName);
        }
        else if (currentStage == 5)
        {
            sceneName = "PresentacionComercial";
            gameManagerScript.ChangeScene(sceneName);
        }
        else if (currentStage == 6)
        {
            sceneName = "Envio";
            gameManagerScript.ChangeScene(sceneName);
        }
    }

    public void OpenPlayerDialog(int n)
    {
        currentStage = n;
        if (currentStage == 2)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogManager>().SetText("Exportador", "En esta sección vamos a realizar los desafíos consernientes a los requisitos mínimos con los que debe contar el comerciante exportador.");
        }else if (currentStage == 3)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogManager>().SetText("Productor", "En esta sección vamos a realizar los desafíos consernientes a los requisitos mínimos con los que debe contar el Productor, quien siembra la Gulupa en este caso.");
        }
        else if (currentStage == 4)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogManager>().SetText("Importador", "En esta sección vamos arealizar los desafíos consernientes a como identificar al importador canadiense.");
        }
        else if (currentStage == 5)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogManager>().SetText("Presentación Comercial", "En esta sección se ven los elementos básicos con los que debe de contar la presentación comercial de la fruta");
        }
        else if (currentStage == 6)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogManager>().SetText("Envío", "¿Qué requisitos y documentos se deben de tener a la mano en el momento del envío");
        }
        else if (currentStage == 7)
        {
            finalScreen.gameObject.SetActive(true);
        }
    }
    public void ClosePlayerDialog()
    {
        playerDialog.gameObject.SetActive(false);
    }

    public void CloseDialog()
    {
        isReadyForALevel++;
        dialogPanel.gameObject.SetActive(false);
        if (isReadyForALevel > 0)
        {
            if(currentStage == 2)
            {
                gameManagerScript.ChangeScene("Exportador");
            }else if (currentStage == 3)
            {
                gameManagerScript.ChangeScene("Exportador");
            }
        }
    }

    private void PrimeraVez()
    {
        dialogPanel.gameObject.SetActive(true);
        GetDialogScript();
        dialogoScript.HiceDancelar();
        dialogoScript.SetText("Exportación de Gulupa", 
            "Bienvenido a este juego con el que reforzarás algunos conceptos clave en el proceso de exportación de la Gulupa (Purple Passion Fruit) desde Colombia hacia Canadá. \n\nA continuación encontrarás un mapa con el progreso que vayas realizando conforme avances en cada módulo.\n\n\n"
            +"Haz click sobre la piedra color Lila");
    }

    private void GetDialogScript()
    {
        dialogoScript = dialogPanel.GetComponent<DialogManager>();
    }

    void UpdateProgressStatus(int newStatus)
    {
        ResetProgressStatusVisuals();
        for(int i = 0; i < newStatus - 1; i++)
        {
            stages[i].GetComponent<SpriteRenderer>().sprite = status[2];//pasado
        }
        stages[newStatus - 1].GetComponent<SpriteRenderer>().sprite = status[1];//nuevo
        // Activar particulas aqui \\
        SetEnabledTargets(newStatus);
    }

    void SetEnabledTargets(int newStatus)
    {
        for(int i=0; i<newStatus; i ++)
        {
            stages[i].GetComponent<LevelTarget>().isEnabled = true;
        }
    }
    void ResetProgressStatusVisuals()
    {
        foreach(GameObject stage in stages)
        {
            stage.GetComponent<SpriteRenderer>().sprite = status[0];//Pendiente
            stage.GetComponent<LevelTarget>().isEnabled = false;
        }
    }
}
