using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public GameObject gameManagerPrefab;
    public GameObject acercaDe;
    public GameObject acercaDeB;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GotoTutorialScene()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("MainMenu");
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
}
