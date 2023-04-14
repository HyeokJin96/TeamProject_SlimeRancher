using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : GSingleton<ObjectPool>
{
    private string bulletPath = "01.YHJ";

    private GameObject[] bulletPrefabs = new GameObject[7];

    GameObject[] bulletBasic = default;


    GameObject[] targetPool = default;

    public override void Awake()
    {
        bulletPrefabs = Resources.LoadAll<GameObject>(bulletPath);

        bulletBasic = new GameObject[500];


        Generate();
    }

    private void Generate()
    {
        for (int index = 0; index < bulletBasic.Length; index++)
        {
            bulletBasic[index] = Instantiate(bulletPrefabs[0]);
            bulletBasic[index].transform.parent = transform;
            bulletBasic[index].SetActive(false);
        }
    }  

    public GameObject MakeObject(string type_)
    {
        switch (type_)
        {
            case "Bullet_Basic":
                targetPool = bulletBasic;
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
            case "Bullet_Basic":
                targetPool = bulletBasic;
                break;
        }

        return targetPool;
    }
}