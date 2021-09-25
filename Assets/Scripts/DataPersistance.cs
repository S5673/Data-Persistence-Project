using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataPersistance : MonoBehaviour
{
    public static DataPersistance Instance;
    public string PlayerName;
    public string BestPlayer;
    public int highScore;
    public int AllTimeHigh;
    public Text BestScore;

    private void Awake()
    {


        // start of new code
        if (Instance != null )
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void UpdateHighScore()
    {
        AllTimeHigh = highScore;
        BestPlayer = PlayerName;
    }

    private void Update()
    {
        BestScore = GameObject.Find("Best Score").GetComponent<Text>();
        BestScore.text = "All Time Best Score: " + BestPlayer + " " + AllTimeHigh;
    }
}
