using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleProperties : MonoBehaviour
{
    public bool isRightOrWrong;
    public TextMesh text;
    public SpriteRenderer image;
    public int id;
    private Rigidbody2D bubbleRb;
    private int range = 5;
    private float forceFactor = 3;
    bool isOnCoroutine = false;
    [SerializeField] private float repeatTime = 1f;
    private bool bubbleType = false;    //  False for text and true for images
    public void Start()
    {
        isOnCoroutine = true;
        bubbleRb = GetComponent<Rigidbody2D>();
        SetScale(GameObject.Find("LevelManager").GetComponent<SetScale>().xScale);
        StartCoroutine(TimeToAddForce());
    }
    IEnumerator TimeToAddForce()
    {
        while (isOnCoroutine == true)
        {
            repeatTime = GameObject.Find("LevelManager").GetComponent<Timming>().time;
            yield return new WaitForSeconds(repeatTime);
            AddRandomForce();
        }
    }

    private void AddRandomForce() {
        forceFactor = GameObject.Find("LevelManager").GetComponent<Force>().force;
        bubbleRb.AddForce(RandomDirection() * forceFactor, ForceMode2D.Impulse);
    }

    private Vector2 RandomDirection()
    {
        Vector2 direction = new Vector2(Random.Range(-range, range), Random.Range(-range, range));
        return direction;
    }

    public void SetBubbleImage(Sprite imagen, bool isR) {
            isRightOrWrong = isR;
            image.gameObject.SetActive(true);
            text.gameObject.SetActive(false);
            image.sprite = imagen;
    }
    public void SetBubbleText(string m, bool isR)
    {
        isRightOrWrong = isR;
        image.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        text.text = m.Replace("\\n", "\n");
    }
    void SetScale(float scaleFactor)
    {
        transform.localScale = new Vector2(transform.localScale.x * scaleFactor, transform.localScale.y * scaleFactor);
    }
    public void AssignId(int n)
    {
        id = n;
    }

    public void AssignValue(bool n)
    {
        isRightOrWrong = n;
    }

    private void OnMouseDown()
    {
        if (isRightOrWrong)//Si es correcto
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Bien();
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Mal(id);
        }
        Destroy(gameObject);
    }
}
