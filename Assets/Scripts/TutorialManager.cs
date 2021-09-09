using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject malDialog;
    public GameObject bubbleSpawner;
    public GameObject globeSpawner;
    public GameObject skipButton;
    private GameManager gameManagerScript;
    public GameObject instruccionConseguiste;
    public GameObject instruccionDinero;
    public int total;
    public int logrados;
    public int counter = 0;
    public int dialogCounter = 0;
    GameObject panelInstructions;
    void Start()
    {
        GetComponent<Timming>().SetTime(1);
        GetComponent<Force>().SetForce(3);
        GetComponent<FallingSpeed>().SetFallingSpeed(4);
        hideInstrucciones();
        instructionsPanel.gameObject.SetActive(true);
        instructionsPanel.GetComponent<Instructions>().SetTexto(
            "Selecciona las burbujas correctas.\n"
            +"\"Click con el mouse si estás desde un computador\" o\n"
            +"\"Tocando la pantalla táctil si estás desde un dispositivo móvil\""
            );
        malDialog.gameObject.SetActive(false);
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManagerScript.SetHiddenLevel(2);    //  Oculta el "Conseguiste" y la cantidad de dinero
        counter = 0;
        dialogCounter = 0;
        hideSkipButton();
    }
    private void FirstMission()
    {
        gameManagerScript.SetHiddenLevel(1);    //  Muestra tanto el "Conseguiste", como la cantidad de dinero
        hideInstrucciones();
        instruccionConseguiste.gameObject.SetActive(true);
        globeSpawner.gameObject.SetActive(false);
    }
    private void SecondMission()
    {
        gameManagerScript.SetHiddenLevel(1);    //  Muestra tanto el "Conseguiste", como la cantidad de dinero
        gameManagerScript.ResetTotal(3);
        gameManagerScript.UpdateMoneyValue(10000000);
        hideInstrucciones();
        instruccionDinero.gameObject.SetActive(true);//  Mejor mostrar las flechas que expliquen la interfáz
    }
    private void ThirdMission()
    {
        gameManagerScript.SetHiddenLevel(1);    //  Muestra tanto el "Conseguiste", como la cantidad de dinero
        hideInstrucciones();
        instructionsPanel.gameObject.SetActive(true);
        instructionsPanel.GetComponent<Instructions>().SetTexto("Selecciona las burbujas con frutas.");
    }
    
    public void ResetGoalValues(int t)
    {
        gameManagerScript.ResetTotal(t);
        total = t;
        logrados = 0;
    }
    public void MissionComplete() {
        counter++;
        if (counter == 1)
        {
            instructionsPanel.gameObject.SetActive(true);
            instructionsPanel.GetComponent<Instructions>().SetTexto("Arrastra las cajas al lado que correspondan, si son Frutas u Hortalizas.");
            bubbleSpawner.gameObject.SetActive(false);
            globeSpawner.gameObject.SetActive(true);
            ResetGoalValues(5);
        }
    }
    public void CloseWindow()
    {
        dialogCounter++;
        instructionsPanel.gameObject.SetActive(false);
        if (dialogCounter == 1) {
            FirstMission();
        }
        else if (dialogCounter == 2)
        {
            SecondMission();
        }
        else if (dialogCounter == 3)
        {
            ThirdMission();
        }
        else if(dialogCounter == 4)
        {
            bubbleSpawner.gameObject.SetActive(true);
            gameManagerScript.ResetTotal(3);
            gameManagerScript.UpdateMoneyValue(10000000);
            ResetGoalValues(bubbleSpawner.GetComponent<BubbleSpawner>().goodImages.Length);
        }
        else if(dialogCounter == 5) {
            MissionComplete();
        }else if(dialogCounter == 7)
        {
            gameManagerScript.SetHiddenLevel(2);    //  Oculta el "Conseguiste" y la cantidad de dinero
            gameManagerScript.isFirstTime = true;
            gameManagerScript.ChangeScene("MainMenu");
        }
    }
    public void CloseMal()
    {
        malDialog.gameObject.SetActive(false);
    }
    public void Mal(int id)
    {
        malDialog.gameObject.SetActive(true);
        malDialog.GetComponent<MalDialogManager>().SetTextContent(
            "Cada fallo es un sobre costo y tiempo de demora\n"
            + "tu dinero se ve reducido en la esquina superior derecha con cada error que cometas."
            );
    }
    public void Bien()
    {
        logrados = logrados+1;
        if(counter == 0)
        {
            if (logrados == total)
            {
                instructionsPanel.gameObject.SetActive(true);
                instructionsPanel.GetComponent<Instructions>().SetTexto(
                    "¡Muy bien!\n"
                    + "Tu progreso se va viendo en \"Conseguiste 3/3\""
                    );
                logrados = 0;
            }
        }
        else if (counter == 1)
        {
            if (logrados == total)
            {
                instructionsPanel.gameObject.SetActive(true);
                instructionsPanel.GetComponent<Instructions>().SetTexto(
                    "¡Muy bien!\n"
                    + "Tu progreso se va viendo en \"Conseguiste 5/5\""
                    );
                logrados = 0;
                counter = 0;
            }
        }
    }

    public void Volver()
    {
        gameManagerScript.ChangeScene("MainMenu");
    }

    // Update is called once per frame
    void hideSkipButton()
    {
        skipButton.gameObject.SetActive(false);
    }
    void showSkipButton()
    {
        skipButton.gameObject.SetActive(true);
    }

    void hideInstrucciones() {
        instruccionConseguiste.gameObject.SetActive(false);
        instruccionDinero.gameObject.SetActive(false);
        instructionsPanel.gameObject.SetActive(false);
    }
}
