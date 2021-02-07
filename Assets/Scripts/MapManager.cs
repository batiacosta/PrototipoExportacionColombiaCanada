using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Sprite[] status;
    public GameObject[] stages;
    public int progress = 1;
    // Start is called before the first frame update
    void Start()
    {
        UpdateProgressStatus(progress);
    }

    // Update is called once per frame

    void UpdateProgressStatus(int newStatus)
    {
        ResetProgressStatusVisuals();
        for(int i = 0; i < newStatus - 1; i++)
        {
            stages[i].GetComponent<SpriteRenderer>().sprite = status[2];//pasado
        }
        stages[newStatus - 1].GetComponent<SpriteRenderer>().sprite = status[1];//nuevo
        // Activar particulas aqui \\
        SetEnabledTargets(newStatus);
    }

    void SetEnabledTargets(int newStatus)
    {
        for(int i=0; i<newStatus; i ++)
        {
            stages[i].GetComponent<LevelTarget>().isEnabled = true;
        }
    }
    void ResetProgressStatusVisuals()
    {
        foreach(GameObject stage in stages)
        {
            stage.GetComponent<SpriteRenderer>().sprite = status[0];//Pendiente
            stage.GetComponent<LevelTarget>().isEnabled = false;
        }
    }
}
