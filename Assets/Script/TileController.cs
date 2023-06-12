using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject[] prefabBlock;
    public startBlock sB;
    public scoreController sC;
    public GameObject instantiateReference;
    public GameObject instantiateBishop; public GameObject instantiateDragon; 
    public GameObject instantiateKnight; public GameObject instantiateRock;
    public SoundController SoC;
    public bool isBlockAttack = false;
    public Collider col;

    void Start()
    {
        sB = GetComponent<startBlock>(); sC = GetComponent<scoreController>();
     
    }
    public static TileController instance;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        attackBlock(); 
        counterToken();
        if (tokenBishop == 3)
        {
            DestroyBishop("Bishop");
             isHideBishop = true;

        }
        if (tokenDragon == 3)
        {
            DestroyDragon("Dragon");
            isHideDragon = true;
        }
        if (tokenKnight == 3)
        {
            DestroyKnight("Knight");
             isHideKnight = true;
        }
        if (tokenRock == 3)
        {
            DestroyRock("Rock");
             isHideRock = true;
        }

    }

    public GameObject indexSpawn;
    public void SetPrefabReference()
    {

    }
    public int numbArrayStart;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.timeScale != 0f)
            {
                numbArrayStart = startBlock.randomIndex;
                instantiateReference = Instantiate(prefabBlock[numbArrayStart], transform.position, Quaternion.identity) as GameObject;
                instantiateReference.transform.SetParent(transform);
                startBlock.instance.isBlockAdd = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Bishop"))
        {            
            scoreController.instance.IncrementScore(2);
            isBlockAttack = true; GameFlow.instance.isCorrect = true; SoundController.instance.sfxBishop();
            tokenBishop += 1;
            countBishop = true; 
            //Debug.Log(countBishop); Debug.Log(tokenBishop);
        }
        if (other.CompareTag("Dragon"))
        {         
            scoreController.instance.IncrementScore(1);
            isBlockAttack = true; GameFlow.instance.isCorrect = true; SoundController.instance.sfxDragon();
            tokenDragon += 1;
            countDragon = true;
        }
        if (other.CompareTag("Knight"))
        {            
            scoreController.instance.IncrementScore(1);
            isBlockAttack = true; GameFlow.instance.isCorrect = true; SoundController.instance.sfxKnight();
            tokenKnight += 1;
            countKnight = true;
        }
        if (other.CompareTag("Rock"))
        {            
            scoreController.instance.IncrementScore(2);
            isBlockAttack = true; GameFlow.instance.isCorrect = true; SoundController.instance.sfxRock();
            tokenRock += 1;
            countRock = true;
        }
    }
    
    public GameObject[] prefabAttack;
    public GameObject atkBoxLine;
    public bool isBoxCross = false;

    public void attackBlock()
    {
        if (isBlockAttack)
        {
          //  Debug.Log(numbArrayStart);
            atkBoxLine = Instantiate(prefabAttack[numbArrayStart], transform.position, Quaternion.identity) as GameObject;
            atkBoxLine.transform.SetParent(transform);            
            Invoke("DestroyBox", 3/2);
            isBlockAttack = false;
        }
    }

    void DestroyBox()
    {
        Destroy(atkBoxLine);
    }
    public static int tokenBishop = 0;
    public bool countBishop = false;
    public static int tokenDragon = 0;
    public bool countDragon = false;
    public static int tokenKnight = 0;
    public bool countKnight = false;
    public static int tokenRock = 0;
    public bool countRock = false;

    public void counterToken()
    {
        if (countBishop)
        {
             Debug.Log("Token Bishop = "+tokenBishop);

            countBishop = false;
            
        }
        
        if (countDragon)
        {
             Debug.Log("Token Dragon = " + tokenDragon);

            countDragon = false;
            
        }
        
        if (countKnight)
        {
             Debug.Log("Token Knight = " + tokenKnight); //Debug.Log(countKnight);

            countKnight = false;
            
        }
        
        if (countRock)
        {
             Debug.Log("Token Rock = " + tokenRock);

            countRock = false;
            
        }
        
    }

    public bool isHideBishop = false; public bool isHideDragon = false;
    public bool isHideKnight = false; public bool isHideRock = false;
    private List<GameObject> objectsToDestroy = new List<GameObject>();

    private GameObject objB;
    public void DestroyBishop(string prefabName)
    {
        if (isHideBishop)
        {
            //Debug.Log("Setelah Destroy Bishop=" + tokenBishop);
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(prefabName);
            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
            tokenBishop = 0;
            isHideBishop = false;
        }
    }
    //private GameObject objD;
    public void DestroyDragon(string prefabName)
    {
        if (isHideDragon)
        {
            //Debug.Log("Setelah Destroy Dragon=" + tokenBishop);
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(prefabName);
            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
            tokenDragon = 0;
            isHideDragon = false;
        }
    }
    //private GameObject objK;
    public void DestroyKnight(string prefabName)
    {
        if (isHideKnight)
        {
            //Debug.Log("Setelah Destroy Knight=" + tokenBishop);
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(prefabName);
            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
            tokenKnight = 0;
            isHideKnight = false;
        }
    }
    //private GameObject objR;
    public void DestroyRock(string prefabName)
    {
        if (isHideRock)
        {
            //Debug.Log("Setelah Destroy Rock=" + tokenBishop);
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(prefabName);
            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
            tokenRock = 0;
            isHideRock = false;
        }
    }
}
