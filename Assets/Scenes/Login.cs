﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GotoTutorialScene()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("Tutorial");
    }
}
