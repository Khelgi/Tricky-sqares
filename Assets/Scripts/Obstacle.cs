using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Vector3 speedRot;
    public static float moveSpeed = 100f;

    Rigidbody2D rigidBody;

     // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        transform.rotation *= Quaternion.Euler(speedRot);
        rigidBody.velocity = new Vector2(moveSpeed * Time.deltaTime, 0); 
    } 
}
