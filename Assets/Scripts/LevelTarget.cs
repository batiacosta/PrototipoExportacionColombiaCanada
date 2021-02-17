using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private PlayerManager playerScript;
    public bool isEnabled;
    public int statusNumber;
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (isEnabled)
        {
            playerScript.current = statusNumber;
            playerScript.SetNewTargetPosition(transform.position, statusNumber);
        }
        else
        {
            //Play sound of Unabled field
        }
    }
}
