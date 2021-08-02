using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlosarioManager : MonoBehaviour
{
    /*
        Activa y desactiva
        1. Panel donde se muestra el glosario la teoría
        2. Panel del juego para evaluaar el conocimiento
        3. Panel de Respuesta correcta.
        4. Panel de Respuesta Incorrecta
        5. Panel de la copa recibida
     */
    public GameObject glossaryGamePanel;
    public GameObject glossaryPanel;
    public GameObject dialogPanel2;
    public GameObject malPanel;
    public GameObject primerPanel;
    public GameObject copaPanel;

    public int currentTerm = 0; // De 0 a 3 imagenes con los glosarios
    public int currentChallenge = 0; // De 0 a 9 preguntas
    /*
     * term 0 => challenge 0, 1
     * term 1 => challenge 2, 3
     * term 2 => challenge 4, 5, 6, 7, 8
     * term 3 => challenge 9
     */
    
    bool isOnlyChallenge = false;
    int bienConteo = 0;
    // Start is called before the first frame update
    void Start()
    {
        //  Abrir Panel para escoger entre Glosario y Omitir
        primerPanel.gameObject.SetActive(true);
    }
    public void EmpezarGlosario() {
        ocultarPanelPrimero();
        isOnlyChallenge = false;
        mostrarContenido();
    }
    public void OmitirGlosario() {
        ocultarPanelPrimero();
        isOnlyChallenge = true;
        mostrarContenido();
    }

    void mostrarContenido() {
        hidePanels();
        if (isOnlyChallenge) {
            MostrarChallenge(currentChallenge);
        }
        else
        {
            if (currentChallenge == 1 || currentChallenge == 3 || currentChallenge == 5 || currentChallenge == 6 || currentChallenge == 7 || currentChallenge == 8)
            {
                MostrarChallenge(currentChallenge);
            }
            else {
                MostrarGlossaryTerm(currentTerm);
            }
        }
    }

    public void moveToChallenge() {
        //  This function is accessed only from the GlossaryTermPanel once the player hits continue
        MostrarChallenge(currentChallenge);
    }

    void mostrarCopa()
    {
        copaPanel.gameObject.SetActive(true);
        copaPanel.GetComponent<CopaPanelManager>().setRealimentacion(currentTerm);
    }

    public void Bien()
    {
        //  Reproducir sonido de correcto
        bienConteo++;
        if (currentTerm==0) {
            if (currentChallenge == 1) {
                if (bienConteo == 2)
                {
                    mostrarCopa();
                }
                else {
                    aumentarChallenge();
                }
                bienConteo = 0;
            }
            else
            {
                aumentarChallenge();
            }
        }
        else if (currentTerm == 1)
        {
            if (currentChallenge == 3)
            {
                if (bienConteo == 2)
                {
                    mostrarCopa();
                }
                else {
                    aumentarChallenge();
                }
                bienConteo = 0;
            }
            else
            {
                aumentarChallenge();
            }
        }
        else if (currentTerm == 2)
        {
            if (currentChallenge == 8)
            {
                if (bienConteo == 5)
                {
                    mostrarCopa();
                }
                else {
                    aumentarChallenge();
                }
                bienConteo = 0;
            }
            else
            {
                aumentarChallenge();
            }
        }
        else if (currentTerm == 3)
        {
            if (currentChallenge == 9)
            {
                if (bienConteo == 1)
                {
                    mostrarCopa();
                }
                else {
                    aumentarChallenge();
                }
                bienConteo = 0;
            }
            else
            {
                aumentarChallenge();
            }
        }
        //aumentarChallenge();
        //  Ver si se acabaron las preguntas para mostrar panel de la copa ganada
    }
    public void Mal()
    {
        //  Mostrar mensaje de error con realimentación
        enableMalPanel();
    }
    public void CerrarPanelMal() {
        aumentarChallenge();
        disableMalPanel();
    }
    public void MostrarGlossaryTerm(int i)
    {
        glossaryPanel.gameObject.SetActive(true);
        glossaryPanel.GetComponent<GlossaryTermManager>().MostrarTerm(i);
    }

    public void MostrarChallenge(int i)
    {
        glossaryGamePanel.gameObject.SetActive(true);
        glossaryGamePanel.GetComponent<GlossaryGamePanelController>().MostrarJuego(i);
    }

    public void continuarPanelCopa()
    {
        //  Cerrar el panel de copa
        cerrarCopaPanel();
        //  Adding a reward on the UI
        agregarCopa();
        aumentarChallenge();
    }
    void cerrarCopaPanel()
    {
        copaPanel.gameObject.SetActive(false);
    }
    void agregarCopa() {
        switch (currentTerm) {
            case 0:
                GameObject.Find("GameManager").GetComponent<GameManager>().bonus[0]++;
                break;
            case 1:
                GameObject.Find("GameManager").GetComponent<GameManager>().bonus[1]++;
                break;
            case 2:
                GameObject.Find("GameManager").GetComponent<GameManager>().bonus[0]++;
                break;
            case 3:
                GameObject.Find("GameManager").GetComponent<GameManager>().bonus[2]++;
                break;
        }
        GameObject.Find("GameManager").GetComponent<GameManager>().AgregarCopa();
    }

    void enableMalPanel() {
        malPanel.gameObject.SetActive(true);
        string pregunta = glossaryGamePanel.GetComponent<GlossaryGamePanelController>().bancoPreguntas[currentChallenge];
        string respuesta = glossaryGamePanel.GetComponent<GlossaryGamePanelController>().bancoPalabras[currentChallenge];
        malPanel.GetComponent<MalGlossaryPanelManager>().SetFeedback(pregunta, respuesta);
    }
    void disableMalPanel() {
        malPanel.gameObject.SetActive(false);
    }
    void aumentarChallenge() {
        currentChallenge++;
        if (currentChallenge == 2 || currentChallenge == 4 || currentChallenge == 9)
        {
            currentTerm++;
        }
        else if (currentChallenge > 9) {
            //  Se termina el módulo
            resetValues();
            hidePanels();
            //  Cambiar de escena
            GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("Progreso");
        }
        mostrarContenido();
    }
    void resetValues() {
        currentChallenge = 0;
        currentTerm = 0;
    }
    void hidePanels() {
        glossaryGamePanel.gameObject.SetActive(false);
        glossaryPanel.gameObject.SetActive(false);
    }
    void ocultarPanelPrimero() {
        primerPanel.gameObject.SetActive(false);
    }
}
