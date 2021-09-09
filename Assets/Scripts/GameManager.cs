using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI moneyT;
    public TextMeshProUGUI timeT;
    public TextMeshProUGUI remainT;
    private AudioSource audioSource;
    public AudioClip bienSound;
    public AudioClip badSound;
    public GameObject copasContainer;
    public GameObject mesesContainer;
    public GameObject[] copasUI;
    public GameObject pausePanel;
    public GameObject seguroPause;
    public Vector2 playerPosition = new Vector2(-7.52f, -2.44f);
    public int enabledLevels = 2;
    public float time = 0;
    public int[] bonus = { 0, 0, 0, 0, 0 };
    public int money = 0;
    public int lives;
    public int logrados;
    public int total = 0;
    public bool isFirstTime = true;
    private string currentScene;
    public int hiddenLevel = 0;
    private TutorialManager tutorialScript;
    private MapManager mapManagerScript;
    public int fallasTotal = 0;
    public int fallas = 0;
    int copasActivas = 0;
    // Start is called before the first frame update
    void Start()
    {
        HideEverything();
        SetCurrentScene();
        audioSource = GetComponent<AudioSource>();
        isFirstTime = true;
        ResetBonusCopas();
        hideMeses();
        resetCopasUI();
    }
    private void Update()
    {
        UpdateVisualValues();
        //CompareResult();
    }
    public void PauseIt()
    {
        pausePanel.gameObject.SetActive(true);
    }
    public void PausaRegresar()
    {
        //  Open confirmation panel
        pausePanel.gameObject.SetActive(false);
        seguroPause.gameObject.SetActive(true);
    }
    public void PauseContinuar()
    {
        //  Close Pause panel
        pausePanel.gameObject.SetActive(false);
    }
    public void PauseAceptar()
    {
        //  Check current scente
        var nombreScene = SceneManager.GetActiveScene().name;
        if(nombreScene == "Glosario")
        {
            GameObject.Find("LevelManager").GetComponent<GlosarioManager>().resetValues();
            ChangeScene("Login");
        }
        if (nombreScene == "Progreso")
        {
            ChangeScene("Login");
            copasActivas = 0;
        }
        else
        {
            ChangeScene("Progreso");
        }
        seguroPause.gameObject.SetActive(false);
        //  Reset values on Scene
        //  Change Scene
    }
    public void PauseConfirmationCancelar()
    {
        seguroPause.gameObject.SetActive(false);
    }

    public void showMeses() {
        mesesContainer.gameObject.SetActive(true);
    }
    public void hideMeses()
    {
        mesesContainer.gameObject.SetActive(false);
    }
    public void AgregarCopa() {
        //  Agrega una copa a la UI
        copasActivas++;
        copasUI[copasActivas - 1].gameObject.SetActive(true);
    }
    public void resetCopasUI() {
        foreach(GameObject c in copasUI)
        {
            c.gameObject.SetActive(false);
        }
    }
    private void CompareResult()
    {
        if (logrados == total)
        {
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                tutorialScript.MissionComplete();
            }
        }
    }
    public void UpdatePlayerPosition(Vector2 pos)
    {
        playerPosition = pos;
    }
    private void UpdateVisualValues() {
        if (hiddenLevel == 0)   //  Muestra todos los valores
        {
            moneyT.text = "$" + money.ToString();
            timeT.text = "Meses: " + time.ToString();
            remainT.text = "Conseguiste " + logrados.ToString() + "/" + total.ToString();
        }else if (hiddenLevel == 1) //  Muestra dinero y remain
        {
            moneyT.text = "$" + money.ToString();
            timeT.text = "";
            remainT.text = "Conseguiste " + logrados.ToString() + "/" + total.ToString();
        }else if (hiddenLevel == 2)//   Oculta todo
        {
            moneyT.text = "";
            timeT.text = "";
            remainT.text = "";
        }
        else if (hiddenLevel == 3)//   Oculta todo
        {
            moneyT.text = "$" + money.ToString();
            timeT.text = "Meses: " + time.ToString();
            remainT.text = "";
        }

    }
    public void SetHiddenLevel(int h)
    {
        hiddenLevel = h;
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        SetCurrentScene();
    }
    public void SetCurrentScene() {
        currentScene = SceneManager.GetActiveScene().name;
        if(currentScene == "Login")
        {
            SetLogin();
        }else if (currentScene == "Tutorial")
        {
            SetTutorial();
        }else if (currentScene == "Progreso")
        {
            //
        }
    }

    private void SetLogin()
    {
        HideEverything();
    }
    public void SetTutorial()
    {
        tutorialScript = GameObject.Find("LevelManager").GetComponent<TutorialManager>();
    }

    public void ResetTotal(int totalN)
    {
        total = totalN;
        logrados = 0;
    }

    private void HideEverything() {

        hiddenLevel = 2;
    }
    public void UpdateMoneyValue(int m)
    {
        money = m;
    }
    public void UpdateTimeValue(int t)
    {
        time = t;
        
    }
    public void UpdateLives(int l)
    {
        lives = l;
    }
    public void Bien()
    {
        logrados++;
        audioSource.clip = bienSound;
        audioSource.Play();
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Tutorial")
        {
            GameObject.Find("LevelManager").GetComponent<TutorialManager>().Bien();
        }else if (currentScene == "Exportador")
        {
            GameObject.Find("LevelManager").GetComponent<ExportadorManager>().Bien();
        }
        else if (currentScene == "Productor")
        {
            GameObject.Find("LevelManager").GetComponent<ProductorManager>().Bien();
        }
        else if (currentScene == "Importador")
        {
            GameObject.Find("LevelManager").GetComponent<ImportadorManager>().Bien();
        }
        else if (currentScene == "PresentacionComercial")
        {
            GameObject.Find("LevelManager").GetComponent<PresentacionComercialManager>().Bien();
        }
        else if (currentScene == "Envio")
        {
            GameObject.Find("LevelManager").GetComponent<EnvioManager>().Bien();
        }
    }
    public void SonarBien()
    {
        audioSource.clip = bienSound;
        audioSource.Play();
    }
    public void Mal(int id)
    {
        money-=5000000;
        time++;
        mesesContainer.GetComponent<SliderManager>().addingValue();
        audioSource.clip = badSound;
        audioSource.Play();
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Tutorial")
        {
            GameObject.Find("LevelManager").GetComponent<TutorialManager>().Mal(id);
        }else if (currentScene == "Exportador")
        {
            GameObject.Find("LevelManager").GetComponent<ExportadorManager>().Mal(id);
        }
        else if (currentScene == "Importador")
        {
            GameObject.Find("LevelManager").GetComponent<ImportadorManager>().Mal(id);
        }
        else if (currentScene == "Productor")
        {
            GameObject.Find("LevelManager").GetComponent<ProductorManager>().Mal(id);
        }
        else if (currentScene == "PresentacionComercial")
        {
            GameObject.Find("LevelManager").GetComponent<PresentacionComercialManager>().Mal(id);
        }
        else if (currentScene == "Envio")
        {
            GameObject.Find("LevelManager").GetComponent<EnvioManager>().Mal(id);

        }
    }

    public void resetFallasTotal()
    {
        fallasTotal = 0;
        fallas = 0;
        bonus[0] = 0;
        bonus[1] = 0;
        bonus[2] = 0;
        resetCopasUI();
    }
    public void resetTimeMoney()
    {
        time = 0;
        mesesContainer.GetComponent<SliderManager>().resetSliderValue();
        money = 0;
        playerPosition = new Vector2(-7.52f, -2.44f);
        enabledLevels = 2;
        isFirstTime = true;
        ChangeScene("Login");
    }
    public void resetFallasLocal()
    {
        fallas = 0;
    }
    public void addFallasLocal()
    {
        fallas++;
    }
    public void compileFallasTotal()
    {
        fallasTotal += fallas;
        resetFallasLocal();
    }
    public void SetCopas() {
        //  Mostrar en el UI i copas
        
    }
    public void SetCopaBonusLevel(int i)
    {

    }

    private void ResetBonusCopas()
    {

        //  Quitr las copas del UI
    }
}
