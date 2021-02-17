using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    GameManager gameManagerScript;
    void Start()
    {
        gameManagerScript = GetComponent<GameManager>();
        gameManagerScript.UpdateMoneyValue(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
