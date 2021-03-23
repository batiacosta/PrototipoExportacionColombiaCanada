using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] disenoGlobo;
    public TextMeshProUGUI izTittle;
    public TextMeshProUGUI deTittle;
    public Sprite[] goodImages;
    public Sprite[] badImages;
    public string[] goodText;
    public string[] badText;
    [SerializeField] private float xRange = 2;
    public GameObject globePrefab;
    public List<GameObject> spawnedGlobes;
    private float spawningTime = 1.4f;
    public bool isImage;
    public int qty;

    public void Start()
    {
        Debug.Log("Entro a Start");
        GetComponent<Rigidbody2D>();
        if (isImage)
        {
            qty = goodImages.Length + badImages.Length;
            Debug.Log(qty);
            StartCoroutine(spawnImages());
        }
        else
        {
            qty = goodText.Length + badText.Length;
            StartCoroutine(spawnText());
        }
    }
    IEnumerator spawnImages()
    {
        qty = goodImages.Length + badImages.Length;
        Debug.Log(badImages.Length);
        Debug.Log(goodImages.Length);
        int randomSpawner = Random.Range(0, 1);

            for (int i = 0; i < badImages.Length; i++)
            {
                spawnedGlobes.Add(Instantiate(globePrefab, setRandomPos(), globePrefab.transform.rotation));
                spawnedGlobes[i].GetComponent<GlobeProperties>().SetGlobeImage(badImages[i], false);
                spawnedGlobes[i].GetComponent<GlobeProperties>().id = i;
                yield return new WaitForSeconds(spawningTime);
            }
            for (int i = 0; i < goodImages.Length; i++)
            {
                spawnedGlobes.Add(Instantiate(globePrefab, setRandomPos(), globePrefab.transform.rotation));
                spawnedGlobes[i+ badImages.Length].GetComponent<GlobeProperties>().SetGlobeImage(goodImages[i], true);
                spawnedGlobes[i + badImages.Length].GetComponent<GlobeProperties>().id = i;
                yield return new WaitForSeconds(spawningTime);
            }

    }

    IEnumerator spawnText()
    {
        qty = goodText.Length + badText.Length;
        for (int i = 0; i < badText.Length; i++)
        {
            spawnedGlobes.Add(Instantiate(globePrefab, setRandomPos(), globePrefab.transform.rotation));
            spawnedGlobes[i].GetComponent<GlobeProperties>().SetGlobeText(badText[i], false);
            spawnedGlobes[i].GetComponent<GlobeProperties>().id = i;
            yield return new WaitForSeconds(spawningTime);
        }
        for (int i = 0; i < goodText.Length ; i++)//badText.Length + goodText.Length
        {
            spawnedGlobes.Add(Instantiate(globePrefab, setRandomPos(), globePrefab.transform.rotation));
            spawnedGlobes[i+ badText.Length].GetComponent<GlobeProperties>().SetGlobeText(goodText[i], true);
            spawnedGlobes[i + badText.Length].GetComponent<GlobeProperties>().id = i;
            yield return new WaitForSeconds(spawningTime);
        }
    }
    private Vector2 setRandomPos()
    {
        Vector2 positionBubble = new Vector2(Random.Range(-xRange, xRange), 15);
        return positionBubble;
    }

}
