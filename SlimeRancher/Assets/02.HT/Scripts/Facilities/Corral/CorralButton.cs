using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorralButton : MonoBehaviour
{
    GameObject foodDispenser;
    Material displayLevel;

    Texture2D[] levelImage;

    int level;

    bool isTarget;
    // Start is called before the first frame update
    void Start()
    {
        foodDispenser = transform.parent.parent.parent.gameObject;
        displayLevel = foodDispenser.transform.GetChild(1).GetChild(3).GetComponent<MeshRenderer>().materials[0];
        levelImage = Resources.LoadAll<Texture2D>("02.HT/Facilities/Corral/FoodDispenser");

        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        imageChange();
        activate();
    }

    void activate()
    {
        // if (UIManager.Instance.corralText.activeSelf == true && Input.GetKeyDown(KeyCode.E))
        // {
        //     Debug.Log("activate");
        //     if (level != 3)
        //     {
        //         level++;
        //     }
        //     else
        //     {
        //         level = 1;
        //     }
        // }
    }

    void imageChange()
    {
        switch (level)
        {
            case 1:
                displayLevel.SetTexture("_MainTexture", levelImage[0]);
                break;
            case 2:
                displayLevel.SetTexture("_MainTexture", levelImage[1]);
                break;
            case 3:
                displayLevel.SetTexture("_MainTexture", levelImage[2]);
                break;
            default:
                break;
        }
    }
}
