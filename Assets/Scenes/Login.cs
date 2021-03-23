using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public GameObject gameManagerPrefab;
    void Start()
    {
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
}
