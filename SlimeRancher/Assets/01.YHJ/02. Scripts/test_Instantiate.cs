using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Instantiate : MonoBehaviour
{
    private ObjectPool objectPool;
    [SerializeField] private GameObject pool;

    private void Awake()
    {
        objectPool = pool.GetComponent<ObjectPool>();
    }

    private void Update()
    {
        Vector3 position = transform.position + Random.insideUnitSphere * 3.8f;

        GameObject newCarrot = objectPool.MakeObject("Carrot", 30);

        if (newCarrot != null)
        {
            newCarrot.transform.position = position;
            newCarrot.SetActive(true);
        }
    }
}
