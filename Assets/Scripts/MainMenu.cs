using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void Volver()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("Login");
    }

    public void GoTutorial()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("Tutorial");
    }

    public void GoToMap()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("Glosario");
    }
}
