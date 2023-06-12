using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBlock : MonoBehaviour
{
    public GameObject[] prefabBlock;
    public GameObject instantiatedPrefab;
    public TileController tc;
    public bool isBlockAdd = false;

    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (prefabBlock.Length > 0)
        {
            randomIndex = Random.Range(0, prefabBlock.Length);
            instantiatedPrefab = Instantiate(prefabBlock[randomIndex], transform.position, Quaternion.identity) as GameObject;
            instantiatedPrefab.transform.SetParent(transform);
        }
    }

    public static startBlock instance;
    private void Awake()
    {
        instance = this;
    }

    
    private void Update()
    {
        changeBlock();

    }
    public static int randomIndex;
    public void SpawnRandomPrefab()
    {
       // destroyWhenGen();
            if (prefabBlock.Length > 0)
            {
                randomIndex = Random.Range(0, prefabBlock.Length);
                instantiatedPrefab = Instantiate(prefabBlock[randomIndex], transform.position, Quaternion.identity) as GameObject;
                instantiatedPrefab.transform.SetParent(transform);
            }      
    }
    
    private void changeBlock()
    {
        //Ganti game object setiap kali pemain menekan tombol "Space"
        if (isBlockAdd)
        {
         //   Debug.Log(tc.isChange);
            Destroy(instantiatedPrefab);
            currentIndex++;
            if (currentIndex >= prefabBlock.Length)
            {
                currentIndex = -1;
            }
            SpawnRandomPrefab();
            isBlockAdd = false;
            //Debug.Log(randomIndex);
        }
    }
}
