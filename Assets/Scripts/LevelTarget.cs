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
            this.GetComponent<Animator>().SetBool("IsEnabled", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("IsEnabled", false);
        }
    }
    public void setEnable(bool isIt) {
        isEnabled = isIt;
    }
    public void NuevoLevelAnim(bool isIt)
    {
        if (isIt)
        {
            this.GetComponent<Animator>().SetBool("IsEnabled", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("IsEnabled", false);
        }
    }
}
