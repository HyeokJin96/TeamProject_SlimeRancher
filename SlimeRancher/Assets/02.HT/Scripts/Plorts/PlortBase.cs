using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlortBase : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public Material material;

    public string plortType;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.materials[0];

        //이후 플로트 생성시 생성한 슬라임에 맞게 색상 설정
        material.color = new Color32(225, 60, 90, 255);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
