using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    public GameObject obstacleBarrelPrefab;
    public GameObject obstacleCratePrefab;
    public GameObject obstacleBarrierPrefab;

    public int poolSize = 10;

    private List<GameObject> obstacleBarrelPool;
    private List<GameObject> obstacleCratePool;
    private List<GameObject> obstacleBarrierPool;

    void Awake()
    {
        obstacleBarrelPool = new List<GameObject>();
        obstacleCratePool = new List<GameObject>();
        obstacleBarrierPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateObject(obstacleBarrelPrefab, obstacleBarrelPool);
            CreateObject(obstacleCratePrefab, obstacleCratePool);
            CreateObject(obstacleBarrierPrefab, obstacleBarrierPool);
        }
    }

    void CreateObject(GameObject prefab, List<GameObject> pool)
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        pool.Add(obj);
    }

    public GameObject Acquire(int obstacleType)
    {
        List<GameObject> pool = GetPool(obstacleType);
        GameObject prefab = GetPrefab(obstacleType);

        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);
        pool.Add(newObj);
        return newObj;
    }

    public void Release(GameObject obstacle, int obstacleType)
    {
        obstacle.SetActive(false);
    }

    private List<GameObject> GetPool(int type)
    {
        if (type == 1) return obstacleBarrelPool;
        if (type == 2) return obstacleCratePool;
        return obstacleBarrierPool;
    }

    private GameObject GetPrefab(int type)
    {
        if (type == 1) return obstacleBarrelPrefab;
        if (type == 2) return obstacleCratePrefab;
        return obstacleBarrierPrefab;
    }
}