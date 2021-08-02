using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GlossaryTermManager : MonoBehaviour
{
    public GameObject glossaryManager;
    public Image imagen;
    public Sprite[] bancoImagenes;
    public void MostrarTerm(int elegido)
    {
        imagen.sprite = bancoImagenes[elegido];
    }

    public void continuarAReto()
    {
        glossaryManager.GetComponent<GlosarioManager>().moveToChallenge();
    }
}
