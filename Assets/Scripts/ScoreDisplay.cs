using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public static int score = 0;
    public int highScore;
    public static bool highScoreDeleted = false;

    [SerializeField] AudioClip resetHighscoreSFX;

    public Animator animator;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highScore = PlayerPrefs.GetInt("SaveScore");
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
        HighScore();
    }

    public void StartGameOverAnimation()
    {
        animator.SetTrigger("GameOver"); 
    }

    public void HighScore()
    {
        if(score > highScore)
        {
            highScore = score;

            PlayerPrefs.SetInt("SaveScore", highScore);
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("SaveScore");
        AudioSource.PlayClipAtPoint(resetHighscoreSFX, Camera.main.transform.position);
        Invoke("LoadMainMenu", 0.5f);
        highScore = 0;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
