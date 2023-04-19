using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCoreTest : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Material material;
    public float alphaValue;

    public bool checkpoint1;
    public bool checkpoint2;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.materials[0];
        checkpoint1 = true;
        alphaValue = material.color.a;
    }

    // Update is called once per frame
    void Update()
    {

        if (alphaValue <= 120)
        {
            checkpoint1 = true;
            checkpoint2 = false;
        }

        if (alphaValue >= 255)
        {
            checkpoint1 = false;
            checkpoint2 = true;
        }

        material.color = new Color32(95, 95, 185, (byte)alphaValue);
        StartCoroutine(SetAlphaValue());
    }

    IEnumerator SetAlphaValue()
    {
        yield return new WaitForSeconds(1f);

        if (checkpoint1)
        {
            alphaValue += 1;
        }

        if (checkpoint2)
        {
            alphaValue -= 1;
        }
    }
}
