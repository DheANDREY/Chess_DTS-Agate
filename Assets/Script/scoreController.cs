using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreController : MonoBehaviour
{
    public bool kondisi1 { get; private set; }
    public int HighScore { get { return score; } }


    public TileController tc;
  //  private static int highScore;
    // Start is called before the first frame update
    void Start()
    {
        ResetCurrentScore();
    }
    public static scoreController instance;
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("ini score=" + score);
           // Debug.Log("ini High score=" + highScore);
        }
    }
    #region Singleton

    private static scoreController _instance = null;

    public static scoreController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<scoreController>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }
    #endregion
    public int score = 0;
    public void IncrementScore(int d)
    {
        score += d;
        SetHighScore();
        //Debug.Log("Berapa skor?" + score);
    }

    public void ResetCurrentScore()
    {
        score = 0;
    }
    public void SetHighScore()
    {
      //  highScore = score;
        // Set high score
        if (score > ScoreDatas.highScore)
        {
            ScoreDatas.highScore = score;
        }
    }
    public int Score
    {
        get { return score; }
    }
}