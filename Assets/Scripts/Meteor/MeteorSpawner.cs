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

    private void Start()
    {
        StartCoroutine(SpawnMeteors(maxMeteorCount));
    }

    Transform GetRandomSpawn(Transform[] spawns)
    {
        return spawns[Random.Range(0, spawns.Length -1)];

    }

    IEnumerator SpawnMeteors(int maxCount)
    {
		for (int i = 0; i < maxCount; i++)
		{
			var spawn = GetRandomSpawn(spawnLocations);
			var meteor = bigMeteorPool.GetObjectFromPool();
			meteor.SetActive(true);
			meteor.transform.position = spawn.position;
            yield return new WaitForSeconds(.5f);
		}
    }
}
