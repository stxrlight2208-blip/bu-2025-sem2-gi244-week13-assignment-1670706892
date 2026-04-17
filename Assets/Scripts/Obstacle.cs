using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int type;
    public ObstacleObjectPool pool;

    void Update()
    {
        
        if (transform.position.x < -10f)
        {
            pool.Release(gameObject, type);
        }
    }
}