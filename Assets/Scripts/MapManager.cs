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
        gameManagerScript.showMeses();
        if (gameManagerScript.isFirstTime)
        {
            gameManagerScript.UpdateMoneyValue(30000000);
            gameManagerScript.UpdateTimeValue(0);
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
        //gameManagerScript.hideMeses();
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
            playerDialog.GetComponent<DialogManager>().SetText("Exportador",
                new string [] { "El exportador debe de cumplir con una serie de certificaciones ante el Instituto Colombiano Agropecuario (ICA) que le permiten unas garantías legales para exportar. Las fallas en el proceso de certificación puede generar retrasos de hasta un año, sin contar con las pérdidas que implican no vender su producto en el exterior." },
            new string[] { "Descripción" }
        );
        }else if (currentStage == 3)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogManager>().SetText("Productor", new string[] {"El exportador debe de seleccionar a un productor certificado que le provea de la gulupa que ofrecerá al Canadá. Este nivel presenta los requisitos mínimos con los que debe contar el productor para ser escogido por el exportador."
                ,"Inocuidad: La inocuidad de los alimentos puede definirse como el conjunto de condiciones y medidas necesarias durante la producción, almacenamiento, distribución y preparación de alimentos para asegurar que una vez ingeridos, no representen un riesgo para la salud." },
            new string[] { "Descripción", "Glosario" }
        );
        }
        else if (currentStage == 4)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogManager>().SetText("Importador", new string[] { "El exportador debe de contactar con una empresa importadora canadiense que compre su producto. En este nivel se ven las características que debe de tener este importador." },
            new string[] { "Descripción"}
        );
        }
        else if (currentStage == 5)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogManager>().SetText("Presentación Comercial", new string[] { "Una presentación comercial que no permita realizar una trazabilidad del producto puede ser rechazada para su distribución en Canadá, lo que implica la pérdida del cargamento. Este nivel muestra los elementos con los que debe de contar la presentación comercial de la Gulupa." },
            new string[] { "Descripción" }
        );
        }
        else if (currentStage == 6)
        {
            playerDialog.gameObject.SetActive(true);
            playerDialog.GetComponent<DialogManager>().SetText("Envío", new string[] { "La gulupa al ser un producto fresco, requiere de unas condiciones para ser transportada. Descuidar las condiciones de envío puede verse reflejado en la pérdida del cargamento, o sobrecostos." },
            new string[] { "Descripción" }
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
        dialogoScript.SetText("Requerimientos Fitosanitarios \npara exportación de Gulupa desde \nColombia a Canadá",

            new string[] {
           "El proceso de exportación de la Gulupa debe superar varios desafíos, entre ellos, las barreras no arancelarias como las fitosanitarias. En este juego, encuentras elementos para identificar los conceptos relacionados a la certificación fitosanitaria, producción, envío y embalaje."
           ,"Fito: Significa: “Planta” o “vegetal”, Definición de La Real Academia Española.\n\n"
           + "Fitosanitario: Es la prevención, y curación de las plantas.\n\n"
           + "Certificado Fitosanitario: Documento oficial que certifica que se cumple con los requerimientos técnicos que debe cumplir el exportador solicitante a la entidad sanitari, avalando el proceso productivo del cultivo, para este caso la Gulupa."
           },
            new string[] { "Descripción", "Glosario" }
        );
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
