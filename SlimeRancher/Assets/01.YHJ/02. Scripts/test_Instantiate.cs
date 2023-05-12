using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Instantiate : MonoBehaviour
{
    public ObjectPool objectPool;
    [SerializeField] private GameObject pool;

    [SerializeField] private test_garden test_garden;

    bool test;
    private void Awake()
    {
        objectPool = pool.GetComponent<ObjectPool>();
    }

    private void Update()
    {
        if (!test && test_garden.isCarrot)
        {
            for (int i = 0; i < 30; i++)
            {
                Vector3 position = transform.position + Random.insideUnitSphere * 3.8f;

                GameObject newCarrot = objectPool.MakeObject("Carrot");
                if (newCarrot != null)
                {
                    newCarrot.transform.position = position;
                    //newCarrot.SetActive(true);
                }
                if (i == 29)
                {
                    test = true;
                }
            }
        }
    }
}
