using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;

    [SerializeField] AudioClip playerBounceSFX;
    [SerializeField] AudioClip playerChangeDirectionSFX;
    [SerializeField] AudioClip playerDeathSFX;

    public Animator animator;

    AudioSource playerAudiosource;

    public float speed = 1f;

    public bool isToPos2 = true;

    private void Start()
    {
        playerAudiosource = GetComponent<AudioSource>();
        PlayerInitAnimation();
        FindObjectOfType<Walls>().WallsInitAnimation();       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ProcessGameOver();
        }
    }

    void ProcessGameOver()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSFX, Camera.main.transform.position);
        FindObjectOfType<ScoreDisplay>().StartGameOverAnimation();
        FindObjectOfType<HighScore>().StartAnimation();
        FindObjectOfType<FadedBackground>().StartUnfadeAnimation();
        FindObjectOfType<RetryButton>().StartShowingRetryButtonAnimation();
        FindObjectOfType<MainMenuButton>().MenuButtonAnimation();

    }

    public void PlayerInitAnimation()
    {
        animator.SetTrigger("StartGame");
    }

    public void PlayerMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isToPos2 = !isToPos2;
            playerAudiosource.PlayOneShot(playerChangeDirectionSFX);
        }

        if (Vector2.Distance(transform.position, pos2.transform.position) <= Mathf.Epsilon)
        {
            isToPos2 = false;
            playerAudiosource.PlayOneShot(playerBounceSFX);
        }
        else if (Vector2.Distance(transform.position, pos1.transform.position) <= Mathf.Epsilon)
        {
            isToPos2 = true;
            playerAudiosource.PlayOneShot(playerBounceSFX);
        }

        if (isToPos2)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos2.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pos1.transform.position, speed * Time.deltaTime);
        }
    }

}

   
  
