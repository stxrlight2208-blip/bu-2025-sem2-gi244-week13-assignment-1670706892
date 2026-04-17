using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    public GameObject obstacleBarrelPrefab;
    public GameObject obstacleBarrierPrefab;
    public GameObject obstacleStoneWallPrefab;

    public int poolSize = 10;

    private List<GameObject> obstacleBarrelPool;
    private List<GameObject> obstacleBarrierPool;
    private List<GameObject> obstacleStoneWallPool;

    void Awake()
    {
        obstacleBarrelPool = new List<GameObject>();
        obstacleBarrierPool = new List<GameObject>();
        obstacleStoneWallPool = new List<GameObject>();

        // 🔹 สร้างของไว้ล่วงหน้า (optional แต่ดี)
        for (int i = 0; i < poolSize; i++)
        {
            CreateObject(obstacleBarrelPrefab, obstacleBarrelPool);
            CreateObject(obstacleBarrierPrefab, obstacleBarrierPool);
            CreateObject(obstacleStoneWallPrefab, obstacleStoneWallPool);
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
        if (type == 2) return obstacleBarrierPool;
        return obstacleStoneWallPool;
    }

    private GameObject GetPrefab(int type)
    {
        if (type == 1) return obstacleBarrelPrefab;
        if (type == 2) return obstacleBarrierPrefab;
        return obstacleStoneWallPrefab;
    }
}
