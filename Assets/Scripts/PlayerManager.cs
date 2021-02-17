using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool isOnTargetPosition = true;
    bool isWaitingForOpeningDialog = false;
    public int currenStagePosition;
    private int temporalNumber = 0;
    private float speed = 5;
    public Vector2 targetPosition;
    public GameObject actualPLayer;
    public int current = 1;
    private Animator playerAnimator;
    private MapManager mapManager;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAnimator = actualPLayer.GetComponent<Animator>();
        playerAnimator.SetBool("iDLE", true);
        mapManager = GameObject.Find("LevelManager").GetComponent<MapManager>();
        transform.position = new Vector2(-7.52f, -2.44f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnTargetPosition) {
            MovePLayerToPosition();
        }
    }

    

    public void SetNewTargetPosition(Vector2 newPosition, int statusNumber) {
        targetPosition = newPosition;
        isOnTargetPosition = false;
        temporalNumber = statusNumber;
        isWaitingForOpeningDialog = true;
    }
    void MovePLayerToPosition() {
        if (temporalNumber < currenStagePosition) {
            if (transform.eulerAngles.y == 0) {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }else if(temporalNumber > currenStagePosition)
        {
            if (transform.eulerAngles.y == 180)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        Vector2 currentPosition = transform.position;
        if (currentPosition == targetPosition) {
            isOnTargetPosition = true;
            playerAnimator.SetBool("iDLE", true);
            if (isWaitingForOpeningDialog)
            {
                //  Show dialog
                mapManager.OpenPlayerDialog(current);
            }
        }
        else
        {
            playerAnimator.SetBool("iDLE", false);
            transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        }
        currenStagePosition = temporalNumber;
    }
}
