using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static atkBox instance;
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
      //  hideAtkBox();
    }
    private void OnTriggerEnter2D(Collider2D box)
    {
        if (box.CompareTag("Bishop"))
        {
            GameFlow.instance.isOver = true;
        }
        if (box.CompareTag("Dragon")) //--Fix
        {
            GameFlow.instance.isOver = true;
        }
        if (box.CompareTag("Knight")) //--Fix
        {
            GameFlow.instance.isOver = true;
        }
        if (box.CompareTag("Rock"))
        {
            GameFlow.instance.isOver = true;
        }
    }
    
}
