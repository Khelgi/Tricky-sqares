using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentHighScore : MonoBehaviour
{
    public Text highscoreText;
    public int highScore;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highScore = PlayerPrefs.GetInt("SaveScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        highscoreText.text = highScore.ToString();
    }
}
