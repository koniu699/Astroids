using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    GameObject prefabForPool;
    [SerializeField]
    int poolCount;

    List<GameObject> freeObjects;
    List<GameObject> busyObjects;

    void Awake()
    {
        InitPull();
    }

    void InitPull()
    {
		freeObjects = new List<GameObject>(poolCount);
		busyObjects = new List<GameObject>(poolCount);

		for (int i = 0; i < poolCount; i++)
		{
            var objectToPull = Instantiate(prefabForPool);
			objectToPull.SetActive(false);
            objectToPull.transform.SetParent(gameObject.transform);
			freeObjects.Add(objectToPull);
		}
    }

    public GameObject GetObjectFromPool()
    {
        GameObject objToRet = null;
        if (freeObjects.Count > 0)
        {
            objToRet = freeObjects[0];
            freeObjects.Remove(objToRet);
            busyObjects.Add(objToRet);
            return objToRet;
        }
        objToRet = Instantiate(prefabForPool);
        busyObjects.Add(objToRet);
        objToRet.transform.SetParent(gameObject.transform);
        return objToRet;
    }

    public void ReturnObjectToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        busyObjects.Remove(objectToReturn);
        freeObjects.Add(objectToReturn);
    }
}
