using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] Transform coinParentTransform;
    [SerializeField] float startDelay = 1f;
    [SerializeField] private float repeatRate = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnCoins");
    }

    private IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            Vector2 position = new Vector2(-7, Random.Range(-2.2f, 2.4f));
            var newObstacle = Instantiate(coin, position, Quaternion.identity);
            newObstacle.transform.parent = coinParentTransform;
            yield return new WaitForSeconds(repeatRate);
        }
    }
}
