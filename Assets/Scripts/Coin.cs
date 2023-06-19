using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100f;

    [SerializeField] AudioClip pickUpSFX;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(pickUpSFX, Camera.main.transform.position);
            ScoreDisplay.score++;
        }
    }
}
