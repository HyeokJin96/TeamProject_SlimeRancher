using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : GSingleton<ObjectPool>
{
    //private string bulletPath = "01.YHJ";

    //private GameObject[] bulletPrefabs = new GameObject[7];

    [SerializeField] private GameObject carrotPrefabs = default;

    GameObject[] carrot = default;

    GameObject[] targetPool = default;

    public override void Awake()
    {
        //bulletPrefabs = Resources.LoadAll<GameObject>(bulletPath);

        carrot = new GameObject[50];


        Generate();
    }

    private void Generate()
    {
        for (int index = 0; index < carrot.Length; index++)
        {
            carrot[index] = Instantiate(carrotPrefabs);
            carrot[index].transform.parent = transform;
            carrot[index].SetActive(false);
        }
    }  

    public GameObject MakeObject(string type_)
    {
        switch (type_)
        {
            case "Carrot":
                targetPool = carrot;
                break;

        }

        for (int index = 0; index < targetPool.Length; index++)
        {

            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }

    private GameObject[] GetPool(string type_)
    {
        switch (type_)
        {
            case "Carrot":
                targetPool = carrot;
                break;
        }

        return targetPool;
    }
}