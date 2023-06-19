using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOperator : MonoBehaviour
{
    public Animator playButtonAnimator, titleAnimator, soundAuthorTextAnimator, highscoreButtonAnimator, soundButtonAnimator;

    [SerializeField] AudioClip playButtonSFX;

    public void StartGame()
    {
        StartCoroutine("ProcessStarting");
    }

    private IEnumerator ProcessStarting()
    {
        AudioSource.PlayClipAtPoint(playButtonSFX, Camera.main.transform.position);
        SceneAnimation();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    public void Restart()
    {
        AudioSource.PlayClipAtPoint(playButtonSFX, Camera.main.transform.position);
        Invoke("LoadGameplayScene", 0.5f);
        FindObjectOfType<RetryButton>().gameObject.SetActive(false);
    }

    public void EscapeToMenu()
    {
        AudioSource.PlayClipAtPoint(playButtonSFX, Camera.main.transform.position);
        Invoke("LoadMainMenu", 0.5f);
    }

    public void GoToSettings()
    {
        AudioSource.PlayClipAtPoint(playButtonSFX, Camera.main.transform.position);
        Invoke("LoadSettings", 0.5f);
    }

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(1);
    }

    public void SceneAnimation()
    {
        playButtonAnimator.SetTrigger("PlayButtonClicked");
        titleAnimator.SetTrigger("PlayButtonClicked");
        soundAuthorTextAnimator.SetTrigger("PlayButtonClicked");
        highscoreButtonAnimator.SetTrigger("PlayButtonClicked");
        soundButtonAnimator.SetTrigger("PlayButtonClicked");
    }


}
