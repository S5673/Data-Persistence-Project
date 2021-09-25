using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public InputField EnterName;
    public Text HighScore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DataPersistance.Instance.PlayerName = PlayerNameChoice();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        DataPersistance.Instance.SaveScore();
        Application.Quit();
    }
    public void GoBack()
    {
        DataPersistance.Instance.highScore = 0;
        SceneManager.LoadScene(0);
    }

    public string PlayerNameChoice()
    {
        return EnterName.GetComponent<InputField>().text;

    }
}
