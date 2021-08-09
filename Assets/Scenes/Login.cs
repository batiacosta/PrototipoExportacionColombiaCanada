using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public GameObject gameManagerPrefab;
    public GameObject acercaDe;
    public GameObject acercaDeB;
    public GameObject acercaDeP;
    public GameObject autoresP;
    public GameObject agradecimientosP;
    public GameObject linksP;
    void Start()
    {
        acercaDe.gameObject.SetActive(false);
        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager == null)
        {
            GameObject instanciaGameManager = Instantiate(gameManagerPrefab);
            instanciaGameManager.gameObject.name = "GameManager";
        }
        else { 
        
        }
        openAcercaDePanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GotoTutorialScene()
    {
        //GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("MainMenu");
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("Progreso");
    }

    public void openAcercade()
    {
        acercaDe.gameObject.SetActive(true);
        acercaDeB.gameObject.SetActive(false);
    }
    public void closeAcercaDe()
    {
        acercaDe.gameObject.SetActive(false);
        acercaDeB.gameObject.SetActive(true);
    }

    public void openAcercaDePanel()
    {
        resetSubPanels();
        acercaDeP.gameObject.SetActive(true);
    }
    public void openAutoresDePanel()
    {
        resetSubPanels();
        autoresP.gameObject.SetActive(true);
    }
    public void openAgradecimientosDePanel()
    {
        resetSubPanels();
        agradecimientosP.gameObject.SetActive(true);
    }
    public void openLinksDePanel()
    {
        resetSubPanels();
        linksP.gameObject.SetActive(true);
    }

    public void resetSubPanels()
    {
        acercaDeP.gameObject.SetActive(false);
        autoresP.gameObject.SetActive(false);
        agradecimientosP.gameObject.SetActive(false);
        linksP.gameObject.SetActive(false);
    }
    public void goToLinkacercaDe()
    {
        Application.OpenURL("https://drive.google.com/file/d/1WtHGcH8bxtk4I7iWwD2Jd1PmJbCFMySp/view?usp=sharing");
    }
}
