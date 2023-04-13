using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlortBase : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public Material material;

    //[PlortType] 0: Default(White), 1: Pink...
    public int plortType;
    List<Color32> plortColor;
    // Start is called before the first frame update

    private void Awake()
    {
        plortColor = new List<Color32>();
        plortColor.Add(Color.white);
        plortColor.Add(new Color32(225, 60, 90, 255));
        //test
        plortColor.Add(Color.black);
    }
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.materials[0];

        //이후 플로트 생성시 생성한 슬라임에 맞게 색상 설정
        //material.color = new Color32(225, 60, 90, 255);
    }

    // Update is called once per frame
    void Update()
    {
        SetPlortColor();
    }

    void SetPlortColor()
    {
        if (material.color == plortColor[0])
        {
            FindPlortColor();
        }
        else { }
    }
    void FindPlortColor()
    {
        for (int i = 0; i < plortColor.Count; i++)
        {
            if (plortType == i)
            {
                material.color = plortColor[i];
            }
        }
    }
}
