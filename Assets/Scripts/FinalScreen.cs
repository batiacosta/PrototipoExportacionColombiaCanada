using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalScreen : MonoBehaviour
{
    public GameObject resetB;
    public TextMeshProUGUI titulo;
    public TextMeshProUGUI tuTiempo;
    public TextMeshProUGUI retraso;
    public TextMeshProUGUI tuSaldo;
    public TextMeshProUGUI sobrecosto;
    private GameManager gameManagerScript;
    private string title;
    private string text;

    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManagerScript.money > 20000000)
        {
            title = "¡Hiciste un excelente trabajo!";
            tuTiempo.text = gameManagerScript.time.ToString() + "\nmeses";
            retraso.text = (gameManagerScript.time - 15.5).ToString() + "\nmeses";
            tuSaldo.text = "$" + gameManagerScript.money.ToString();
            sobrecosto.text = "$" + (30000000 - gameManagerScript.money).ToString();
            text = "El tiempo aproximado del proceso entero de certificaciones es de 15.5 meses, sin embargo, en el juego tu proceso tardó "
                + gameManagerScript.time.ToString() +
                " meses, es decir " + (gameManagerScript.time - 15.5).ToString() + " meses más. Adicionalmente, tu dinero es de $" + gameManagerScript.money.ToString()
                + ", significa que tus sobrecostos fueron de $"
                + (30000000 - gameManagerScript.money).ToString() + ". Buen trabajo.";
        }else if (gameManagerScript.money > 0 && gameManagerScript.money <=20000000)
        {
            title = "Pudiste hacerlo mejor";
            tuTiempo.text = gameManagerScript.time.ToString() + "\nmeses";
            retraso.text = (gameManagerScript.time - 15.5).ToString() + "\nmeses";
            tuSaldo.text = "$" + gameManagerScript.money.ToString();
            sobrecosto.text = "$" + (30000000 - gameManagerScript.money).ToString();
            text = "El tiempo aproximado del proceso entero de certificaciones es de 15.5 meses, sin embargo, en el juego tu proceso tardó "
                + gameManagerScript.time.ToString() +
                " meses, es decir " + (gameManagerScript.time - 15.5).ToString() + " meses más. Adicionalmente, tu dinero es de $" + gameManagerScript.money.ToString()
                + ", significa que tus sobrecostos fueron de $"
                + (30000000 - gameManagerScript.money).ToString() + ". Puedes intentarlo nuevamente para mejorar";
        }
        else if (gameManagerScript.money <0)
        {
            title = "Intentalo nuevamente";
            tuTiempo.text = gameManagerScript.time.ToString() + "\nmeses";
            retraso.text = (gameManagerScript.time - 15.5).ToString() + "\nmeses";
            tuSaldo.text = "$" + gameManagerScript.money.ToString();
            sobrecosto.text = "$" + (30000000 - gameManagerScript.money).ToString();
            text = "El tiempo aproximado del proceso entero de certificaciones es de 15.5 meses, sin embargo, en el juego tu proceso tardó "
                + gameManagerScript.time.ToString() +
                " meses, es decir " + (gameManagerScript.time-15.5).ToString() +" meses más. Adicionalmente, tu dinero es de $" + gameManagerScript.money.ToString()
                + ", significa que tus sobrecostos fueron de $"
                + (30000000 - gameManagerScript.money).ToString() + ". Te sugerimos revisar los conceptos e intentarlo nuevamente.";
        }
        titulo.text = title;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToForm()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLScL3oQInOUGRfYVrVUs2LIE4A0eBheZzRKskHlovnJpfh2-zw/viewform?usp=sf_link");
    }

    public void ResetGame()
    {
        gameManagerScript.hideMeses();
        gameManagerScript.SetHiddenLevel(2);
        gameManagerScript.resetFallasTotal();
        gameManagerScript.resetTimeMoney();
        gameManagerScript.ChangeScene("Login");
    }
}
