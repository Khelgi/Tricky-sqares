using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacles;
    [SerializeField] Transform obstacleParentTransform;

    public float startDelay = 1f;
    public float repeatRate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacles");
    }

    void Update()
    {
       IncreasingDifficulty();
    }

    private IEnumerator SpawnObstacles()
    {
       yield return new WaitForSeconds(startDelay);
        
        while (true)
        {
            Vector2 position = new Vector2(-7, Random.Range(-2.2f, 2.4f));
            var newObstacle = Instantiate(obstacles, position, Quaternion.identity);
            newObstacle.transform.parent = obstacleParentTransform;
            yield return new WaitForSeconds(repeatRate);
        }
    }

    void IncreasingDifficulty()
    {

        if (ScoreDisplay.score >= 5 && ScoreDisplay.score < 10)
        {
            Obstacle.moveSpeed = 130f;
            repeatRate = 4f;
        }
        else if (ScoreDisplay.score >= 10 && ScoreDisplay.score < 15)
        {
            Obstacle.moveSpeed = 160f;
            repeatRate = 3f;
        }
        else if (ScoreDisplay.score >= 15 && ScoreDisplay.score < 20)
        {
            Obstacle.moveSpeed = 190f;
            repeatRate = 2f;
        }
        else if (ScoreDisplay.score >= 20 && ScoreDisplay.score < 25)
        {
            Obstacle.moveSpeed = 220f;
            repeatRate = 1f;
        }
        else if (ScoreDisplay.score >= 25)
        {
            Obstacle.moveSpeed = 250f;
            repeatRate = 0.5f;
        }
        else
        {
            Obstacle.moveSpeed = 100f;
            repeatRate = 5f;
        }
    }
} 
