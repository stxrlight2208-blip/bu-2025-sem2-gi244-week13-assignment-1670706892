using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public ObstacleObjectPool pool;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 2f);
    }

    void Spawn()
    {
        GameObject player = GameObject.Find("Player");
        bool isGameOver = player.GetComponent<PlayerController>().gameOver;

        if (isGameOver)
        {
            return;
        }

        int randomType = Random.Range(1, 4);

        GameObject obstacle = pool.Acquire(randomType);

        
        Obstacle obs = obstacle.GetComponent<Obstacle>();
        obs.pool = pool;
        obs.type = randomType;

        obstacle.transform.position = spawnPoint.position;
    }
}