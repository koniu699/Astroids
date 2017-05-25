using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField]
    ObjectPool bigMeteorPool;
    [SerializeField]
    int maxMeteorCount;
    [SerializeField]
    Transform[] spawnLocations;
    [SerializeField]
    float meteorSpawnDelay;

    public int MeteorCount
    {
        get
        {
            return maxMeteorCount;
        }
        set
        {
            maxMeteorCount = value;
            if (maxMeteorCount <= 0)
                maxMeteorCount = 1;
        }
    }

    private void Awake()
    {
        GlobalGameController.Instance.RegisterMeteorSpawner(this);
    }

    private void Start()
    {
        SpawnMeteors();
    }

    Transform GetRandomSpawn(Transform[] spawns)
    {
        return spawns[Random.Range(0, spawns.Length - 1)];

    }

    IEnumerator SpawnMeteors(int maxCount)
    {
        for (int i = 0; i < maxCount; i++)
        {
            var spawn = GetRandomSpawn(spawnLocations);
            var meteor = bigMeteorPool.GetObjectFromPool();
            meteor.SetActive(true);
            meteor.transform.position = spawn.position;
            yield return new WaitForSeconds(meteorSpawnDelay);
        }
    }

    public void SpawnMeteors()
    {
        StartCoroutine(SpawnMeteors(maxMeteorCount));
    }
}
