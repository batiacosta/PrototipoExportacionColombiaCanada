using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool isOnTargetPosition = true;
    public Vector2 targetPosition;
    [SerializeField] float speed = 10;
    public GameObject actualPLayer;
    private Animator playerAnimator;
    public int currenStagePosition;
    MapManager mapManager;
    int temporalNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
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

    public void SetNewTargetPosition(Vector2 newPosition,int statusNumber) {
        targetPosition = newPosition;
        isOnTargetPosition = false;
        temporalNumber = statusNumber;
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
        }
        else
        {
            playerAnimator.SetBool("iDLE", false);
            transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        }
        currenStagePosition = temporalNumber;
    }
}
