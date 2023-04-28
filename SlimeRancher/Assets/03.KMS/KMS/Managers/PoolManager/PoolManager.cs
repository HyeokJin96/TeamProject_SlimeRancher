using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Want Prefab To Pool
    public GameObject prefabToPool;
    // For Arrangement
    public GameObject waitingRoom;
    //
    private GameObject[] gameObjects;
    
    // How Many Prefabs Want to Create
    public int HowMany = 0;
    //
    private int index = 0;

    void Start()
    {
        CreatePrefabs();
    }

    void Update()
    {
        HowToActive();
    }

    // { Create Prefabs
    private void CreatePrefabs()
    {
        // How Many Prefabs Want to Create
        gameObjects = new GameObject[HowMany];

        // Loop for Create 
        for (int i = 0; i < HowMany; i++)
        {
            // Create Prefabs
            GameObject Prefab = Instantiate(prefabToPool);

            // Numbering
            gameObjects[i] = Prefab;

            // Arrangement
            Prefab.transform.SetParent(waitingRoom.transform);

            // Active Prefab False
            Prefab.SetActive(false);
        }
    }
    // } Create Prefabs

    // { How To Active
    void HowToActive()
    {
        // Active terms
        if (Input.GetKey(KeyCode.Space))
        {
            // Active Prefab True
            gameObjects[index].SetActive(true);

            // Create Position
            gameObjects[index].transform.position = transform.position;

            // Index Count
            index++;

            // If Count Last Number, Restart 0
            if (index == HowMany) index = 0;
        }
    }
    // } How To Active
}