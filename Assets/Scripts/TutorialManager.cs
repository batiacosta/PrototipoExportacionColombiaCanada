using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject malDialog;
    public GameObject bubbleSpawner;
    public GameObject globeSpawner;
    private GameManager gameManagerScript;
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
        instructionsPanel.gameObject.SetActive(true);
        instructionsPanel.GetComponent<Instructions>().SetTexto("En este tutorial deberás hacer click sobre las burbujas correctas y tu progreso se ve reflejado en la parte superior.");
        malDialog.gameObject.SetActive(false);
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManagerScript.SetHiddenLevel(1);
        counter = 0;
        dialogCounter = 0;
        //FirstMission();
    }
    private void FirstMission()
    {
        instructionsPanel.gameObject.SetActive(true);
        instructionsPanel.GetComponent<Instructions>().SetTexto("Selecciona unicamente las burbujas con Frutas.");
        globeSpawner.gameObject.SetActive(false);
    }
    public void ResetGoalValues(int t)
    {
        total = t;
        logrados = 0;
    }
    public void MissionComplete() {
        counter++;
        if (counter == 1)
        {
            instructionsPanel.gameObject.SetActive(true);
            instructionsPanel.GetComponent<Instructions>().SetTexto("Arrastra las cajas al lado que correspondan, si son Frutas u Hortalizas");
            bubbleSpawner.gameObject.SetActive(false);
            globeSpawner.gameObject.SetActive(true);
            gameManagerScript.ResetTotal(5);
            counter = 0;
            ResetGoalValues(4);
        }
    }
    public void CloseWindow()
    {
        dialogCounter++;
        instructionsPanel.gameObject.SetActive(false);
        if (dialogCounter == 1) {
            FirstMission();
        }
        else if(dialogCounter == 2)
        {
            bubbleSpawner.gameObject.SetActive(true);
            gameManagerScript.ResetTotal(3);
            gameManagerScript.UpdateMoneyValue(10000);
            ResetGoalValues(bubbleSpawner.GetComponent<BubbleSpawner>().goodImages.Length);
        }
        else if(dialogCounter == 3) {
            MissionComplete();
        }else if(dialogCounter == 5)
        {
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
        malDialog.GetComponent<MalDialogManager>().SetTextContent("Tu dinero se reducirá porque cada error representa un sobrecosto en dinero y tiempo por cada trámite que falles");
    }
    public void Bien()
    {
        logrados = logrados+1;
        if(logrados == total)
        {

                instructionsPanel.gameObject.SetActive(true);
                instructionsPanel.GetComponent<Instructions>().SetTexto("¡Felicidades, ahora vamos por el siguiente reto!");
                logrados = 0;  
        }
    }

    public void Volver()
    {
        gameManagerScript.ChangeScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
