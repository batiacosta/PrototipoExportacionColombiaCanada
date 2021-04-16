using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalScreen : MonoBehaviour
{
    public GameObject resetB;
    public TextMeshProUGUI texto;
    public TextMeshProUGUI titulo;
    private GameManager gameManagerScript;
    private string title;
    private string text;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManagerScript.money > 20000000)
        {
            title = "¡Hiciste un excelente trabajo!";
            text = "El tiempo aproximado del proceso entero de certificaciones es de 15.5 meses, sin embargo, en el juego tu proceso tardó "
                + gameManagerScript.time.ToString() +
                " meses, es decir " + (gameManagerScript.time - 15.5).ToString() + " meses más. Adicionalmente, tu dinero es de $" + gameManagerScript.money.ToString()
                + ", significa que tus sobrecostos fueron de $"
                + (30000000 - gameManagerScript.money).ToString() + ". Buen trabajo.";
        }else if (gameManagerScript.money > 0 && gameManagerScript.money <=20000000)
        {
            title = "Pudiste hacerlo mejor";
            text = "El tiempo aproximado del proceso entero de certificaciones es de 15.5 meses, sin embargo, en el juego tu proceso tardó "
                + gameManagerScript.time.ToString() +
                " meses, es decir " + (gameManagerScript.time - 15.5).ToString() + " meses más. Adicionalmente, tu dinero es de $" + gameManagerScript.money.ToString()
                + ", significa que tus sobrecostos fueron de $"
                + (30000000 - gameManagerScript.money).ToString() + ". Puedes intentarlo nuevamente para mejorar";
        }
        else if (gameManagerScript.money <0)
        {
            title = "Intentalo nuevamente";
            text = "El tiempo aproximado del proceso entero de certificaciones es de 15.5 meses, sin embargo, en el juego tu proceso tardó "
                + gameManagerScript.time.ToString() +
                " meses, es decir " + (gameManagerScript.time-15.5).ToString() +" meses más. Adicionalmente, tu dinero es de $" + gameManagerScript.money.ToString()
                + ", significa que tus sobrecostos fueron de $"
                + (30000000 - gameManagerScript.money).ToString() + ". Te sugerimos revisar los conceptos e intentarlo nuevamente.";
        }
        titulo.text = title;
        texto.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToForm()
    {
        Application.OpenURL("https://forms.gle/15dwWNvMzTXYwZ5z5");
    }

    public void ResetGame()
    {
        gameManagerScript.resetFallasTotal();
        gameManagerScript.resetTimeMoney();
    }
}
