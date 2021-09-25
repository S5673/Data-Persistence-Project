using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        LoadScore();

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

    [System.Serializable]
    class SaveData
    {
        public string BestPlayer;
        public int AllTimeHigh;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.AllTimeHigh = AllTimeHigh;
        data.BestPlayer = BestPlayer;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.BestPlayer;
            AllTimeHigh = data.AllTimeHigh;
        }
    }
}
