using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectPulling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject Prefab;
        public int size;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDirectory;


    public static ObjectPulling instance;
    private void Awake()
    {
        instance= this;
    }
    private void Start()
    {
       poolDirectory = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();    
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }
            poolDirectory.Add(pool.tag, objectpool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, quaternion rotation)
    {
        if (!poolDirectory.ContainsKey(tag))
        {
            Debug.Log("pool could not be found");
            return null;
        }
       GameObject objectTospawn  =  poolDirectory[tag].Dequeue();
        objectTospawn.SetActive(true);
        objectTospawn.transform.position = position;
        objectTospawn.transform.rotation = rotation;
        poolDirectory[tag].Enqueue(objectTospawn);

        return objectTospawn;
    }

}
