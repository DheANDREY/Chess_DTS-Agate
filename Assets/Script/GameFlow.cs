using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    public GameObject menuLose;
    public Image timeFill;
    float timeRemaining;
    public float maxTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = maxTime;
    }
    public static GameFlow instance;
    private void Awake()
    {
        instance = this;
    }
    public bool isCorrect = false;
    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timeFill.fillAmount = timeRemaining / maxTime;
        }       
        
        if(timeRemaining <= 0)
        {           
            GameOverTime();
        }

        if (isCorrect)
        {
            timeRemaining += 10.0f;
            if (timeRemaining >= 10)
            {
                timeRemaining = 10;
            }
            isCorrect = false;
        }
      GameOver();
        
    }
    public bool isOver = false;
    public void GameOver()
    {
        if (isOver)
        {
            Time.timeScale = 0f;
            menuLose.SetActive(true);
            isOver = false;
        }
    }
    public void GameOverTime()
    {
            Time.timeScale = 0f;
            menuLose.SetActive(true);
            isOver = false;
            
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        timeRemaining = maxTime;
        TileController.tokenBishop = 0;
        TileController.tokenDragon = 0;
        TileController.tokenKnight = 0;
        TileController.tokenRock = 0;
    }
}
