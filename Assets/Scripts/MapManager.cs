using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapManager : MonoBehaviour
{
    public Sprite[] status;
    public GameObject[] stages;
    public GameObject dialogPanelMap;
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
            gameManagerScript.UpdateMoneyValue(30000000);
            gameManagerScript.UpdateTimeValue(0);
            gameManagerScript.isFirstTime = false;
        }
        
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
            playerDialog.GetComponent<DialogMapManagerCups>().SetText("Exportador",
                new string [] { "El exportador cumple con una serie de requisitos ante el ICA que le dan garantías legales para exportar la Gulupa." },
                2, gameManagerScript.bonus[0]
            
        );
        }else if (currentStage == 3)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogMapManagerCups>().SetText("Productor", new string[] { "El productor debe de contar con certificado ICA para ser escogido por el exportador." },
                6, gameManagerScript.bonus[2]

        );
        }
        else if (currentStage == 4)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogMapManagerCups>().SetText("Importador", new string[] { "Es el empresario canadiense que compra la gulupa al exportador colombiano." },
            1, 0
        );
        }
        else if (currentStage == 5)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogMapManagerCups>().SetText("Presentación Comercial", new string[] { "La presentación comercial que no permita una trazabilidad, es rechazada en Canadá." },
            1, gameManagerScript.bonus[1]
        );
        }
        else if (currentStage == 6)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogMapManagerCups>().SetText("Envío", new string[] { "La Gulupa requiere unas condiciones de transporte por ser un producto fresco." },
            1, 0
        );
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
        gameManagerScript.showMeses();
        dialogPanel.gameObject.SetActive(false);
        dialogPanelMap.gameObject.SetActive(false);
        gameManagerScript.SetHiddenLevel(3);
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
        gameManagerScript.showMeses();
        //gameManagerScript.Set
        GetDialogScript();
        dialogPanel.GetComponent<DialogManager>().SetText("La ruta exportadora de la Gulupa a Canadá",

            new string[] {
           "La duración total del proceso en la exportación de la Gulupa está estimada en 16 meses. La barra verde es la referencia del tiempo, si excedes ese tiempo, significa que el proceso de exportación presentó retrasos."
           }
        );
    }

    private void GetDialogScript()
    {
        dialogoScript = dialogPanelMap.GetComponent<DialogManager>();
    }

    void UpdateProgressStatus(int newStatus)
    {
        ResetProgressStatusVisuals();
        for(int i = 0; i < newStatus - 1; i++)
        {
            stages[i].GetComponent<SpriteRenderer>().sprite = status[2];//pasado
            stages[i].GetComponent<LevelTarget>().NuevoLevelAnim(false);
        }
        stages[newStatus - 1].GetComponent<SpriteRenderer>().sprite = status[1];//nuevo
        stages[newStatus - 1].GetComponent<LevelTarget>().NuevoLevelAnim(true) ;
        // Activar particulas aqui \\
        SetEnabledTargets(newStatus);
    }

    void SetEnabledTargets(int newStatus)
    {
        for(int i=0; i<newStatus; i ++)
        {
            stages[i].GetComponent<LevelTarget>().setEnable(true);
        }
    }
    void ResetProgressStatusVisuals()
    {
        foreach(GameObject stage in stages)
        {
            stage.GetComponent<SpriteRenderer>().sprite = status[0];//Pendiente
            stage.GetComponent<LevelTarget>().setEnable(false);
        }
    }
    public void Volver()
    {
        gameManagerScript.ChangeScene("MainMenu");
    }
}
