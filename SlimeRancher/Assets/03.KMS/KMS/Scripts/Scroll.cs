using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeed = 0.2f;
    Material myMat;

    void Start()
    {
        myMat = gameObject.GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Scroll Texture
        float newOffsetY = myMat.mainTextureOffset.y - scrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(0, newOffsetY);

        myMat.mainTextureOffset = newOffset;
    }
}
