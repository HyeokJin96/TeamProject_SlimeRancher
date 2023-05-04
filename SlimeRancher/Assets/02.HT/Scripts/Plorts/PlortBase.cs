using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlortBase : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public Material material;

    //[PlortType] 0: Default(White), 1: Pink...
    public int plortType;
    public List<Color32> plortColor;    //test public

    public List<string> plortName;
    public Sprite[] plortIcon;
    // Start is called before the first frame update

    private void Awake()
    {
        plortColor = new List<Color32>();
        plortColor.Add(new Color32(255, 255, 255, 255));
        plortColor.Add(new Color32(225, 60, 90, 255));  //pink
        plortColor.Add(new Color32(30, 125, 200, 255));  //rock
        plortColor.Add(new Color32(75, 75, 75, 255));  //tabby
        plortColor.Add(new Color32(175, 175, 255, 200));  //phosphor
        plortColor.Add(new Color32(225, 60, 90, 255));  //boom(=pink)
        plortColor.Add(new Color32(25, 125, 25, 255));  //Rad

        plortName = new List<string>();
        plortName.Add("Empty");
        plortName.Add("Pink Plort");
        plortName.Add("Rock Plort");
        plortName.Add("Tabby Plort");
        plortName.Add("Phosphor Plort");
        plortName.Add("Boom Plort");
        plortName.Add("Rad plort");
        //ing
        plortIcon = Resources.LoadAll<Sprite>("02.HT/QuickSlotIcon/Plorts");
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
