using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class GlobeProperties : MonoBehaviour
{
    public TextMeshProUGUI text;
    public SpriteRenderer image;
    public bool isRightWrong;
    public int id;
    public float speed = 2;
    Vector3 mousePosition;
    public float followSpeed = 1000;
    bool isDrag = false;
    int xBound = 5;

    [SerializeField] private float xRange = 8;
    [SerializeField] private float yBound = -17;
    // Start is called before the first frame update
    public void AssignId(int i)
    {
        id = i;
    }

    // Update is called once per frame
    void Start()
    {
        speed = GameObject.Find("LevelManager").GetComponent<FallingSpeed>().fallingSpeed;
        GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        if (!isDrag)
        {
            if (transform.position.y < yBound)
            {
                transform.position = new Vector2(transform.position.x, 15);
            }
            Move();
        }
        if(transform.position.x >5 || transform.position.x < -5)
        {
            transform.position = new Vector2(0, transform.position.y);
        }
    }
    public void SetGlobeImage(Sprite imagen, bool right)
    {
        image.gameObject.SetActive(true);
        text.gameObject.SetActive(false);
        image.sprite = imagen;
        isRightWrong = right;
    }
    public void SetGlobeText(string m, bool right)
    {
        image.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        text.text = m;
        isRightWrong = right;
    }
    public void Move()
    {
        transform.Translate(new Vector2(0, -1*speed*Time.deltaTime));
    }
    private void OnMouseDown()
    {
        isDrag = true;
    }
    private void OnMouseDrag()
    {
        transform.localPosition = Vector2.Lerp(transform.position, new Vector2(Input.GetAxis("Mouse X") * 8, Input.GetAxis("Mouse Y")), followSpeed * Time.deltaTime);
    }
    private void OnMouseUp()
    {
        isDrag = false;
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isRightWrong)//Correcto es derecha
        {
            if (collision.CompareTag("De"))
            {
                //Good answer
                GameObject.Find("GameManager").GetComponent<GameManager>().Bien();
                Destroy(gameObject);
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Mal(id);
            }
        }
        else
        {
            if (collision.CompareTag("Iz"))
            {
                //Good answer
                GameObject.Find("GameManager").GetComponent<GameManager>().Bien();
                Destroy(gameObject);
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Mal(id);
            }
        }
    }
}
