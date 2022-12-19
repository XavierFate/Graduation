using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public int obstaclePoolSize = 5;
    public GameObject obstaclePrefab;
    public float spawnRate = 4f;
    public float obstacleMin = -1f;
    public float obstacleMax = 3.5f;

    private GameObject[] obstacles;
    private Vector2 objectPoolPosition = new Vector2(-15f , -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentObstacle = 0;
    // Start is called before the first frame update
    void Start()
    {
        obstacles = new GameObject[obstaclePoolSize];
        for (int i = 0; i < obstaclePoolSize; i++)
        {
            obstacles[i] = (GameObject)Instantiate(obstaclePrefab, objectPoolPosition, Quaternion.identity); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if(GameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(obstacleMin, obstacleMax);

            obstacles[currentObstacle].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
            currentObstacle++;
            if(currentObstacle >= obstaclePoolSize)
            {
                currentObstacle = 0;
            }
        }
    }
}
