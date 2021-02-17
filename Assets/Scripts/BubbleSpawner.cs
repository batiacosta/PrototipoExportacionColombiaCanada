using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public Sprite[] goodImages;
    public Sprite[] badImages;
    public string[] goodText;
    public string[] badText;
    public float bubbleScale = 0.5f;
    public GameObject burbujaPrefab;
    public List<GameObject> spawnedBubbles;
    public bool typeBubble;
    private float xRange = 9;
    private float yRange = 4;
    // Start is called before the first frame update
    public void Start()
    {
        int qty;
        if (typeBubble)//Bubble images
        {
            qty = goodImages.Length + badImages.Length;
            SetBubbleImages();
        }
        else
        {
            qty = goodText.Length + badText.Length;
            SetBubbleText();
        }
        
    }
    void SetBubbleImages()
    {
        for (int i = 0; i < badImages.Length; i++)
        {
            spawnedBubbles.Add(Instantiate(burbujaPrefab, setRandomPos(), burbujaPrefab.transform.rotation));
            spawnedBubbles[i].GetComponent<BubbleProperties>().SetBubbleImage(badImages[i], false);
            spawnedBubbles[i].GetComponent<BubbleProperties>().id = i;
            spawnedBubbles[i].GetComponent<BubbleProperties>().Start();
            spawnedBubbles[i].transform.parent = gameObject.transform;
        }
        for (int i = badImages.Length; i < badImages.Length + goodImages.Length; i++)
        {
            spawnedBubbles.Add(Instantiate(burbujaPrefab, setRandomPos(), burbujaPrefab.transform.rotation));
            spawnedBubbles[i].GetComponent<BubbleProperties>().SetBubbleImage(goodImages[i - badImages.Length], true);
            spawnedBubbles[i].GetComponent<BubbleProperties>().id = i;
            spawnedBubbles[i].GetComponent<BubbleProperties>().Start();
            spawnedBubbles[i].transform.parent = gameObject.transform;
        }
    }
    void SetBubbleText()
    {
        for (int i = 0; i < badText.Length; i++)
        {

            spawnedBubbles.Add(Instantiate(burbujaPrefab, setRandomPos(), burbujaPrefab.transform.rotation));
            spawnedBubbles[i].GetComponent<BubbleProperties>().SetBubbleText(badText[i], false);
            spawnedBubbles[i].GetComponent<BubbleProperties>().id = i;
            spawnedBubbles[i].GetComponent<BubbleProperties>().Start();
            spawnedBubbles[i].transform.parent = gameObject.transform;
        }
        for (int i = badText.Length; i < badText.Length + goodText.Length; i++)
        {
            spawnedBubbles.Add(Instantiate(burbujaPrefab, setRandomPos(), burbujaPrefab.transform.rotation));
            spawnedBubbles[i].GetComponent<BubbleProperties>().SetBubbleText(goodText[i - badText.Length], true);
            spawnedBubbles[i].GetComponent<BubbleProperties>().id = i;
            spawnedBubbles[i].GetComponent<BubbleProperties>().Start();
            spawnedBubbles[i].transform.parent = gameObject.transform;
        }
    }

    private Vector2 setRandomPos()
    {
        Vector2 positionBubble = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));
        return positionBubble;
    }

}
