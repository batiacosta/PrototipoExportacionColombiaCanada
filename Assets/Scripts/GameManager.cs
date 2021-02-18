using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public GameObject dialogPanel;
    //public GameObject finalScreen;
    //public GameObject malBox;
    public TextMeshProUGUI moneyT;
    public TextMeshProUGUI timeT;
    public TextMeshProUGUI remainT;
    private AudioSource audioSource;
    public AudioClip bienSound;
    public AudioClip badSound;
    public Vector2 playerPosition = new Vector2(-7.52f, -2.44f);
    public int enabledLevels = 2;
    public int time = 0;
    public int money = 10000;
    public int lives;
    public int logrados;
    public int total = 0;
    public bool isFirstTime = false;
    private string currentScene;
    public int hiddenLevel = 0;
    private TutorialManager tutorialScript;
    private MapManager mapManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        HideEverything();
        SetCurrentScene();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        UpdateVisualValues();
        //CompareResult();
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
    }
    public void Mal(int id)
    {
        money-=1000;
        time++;
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
    }

}
