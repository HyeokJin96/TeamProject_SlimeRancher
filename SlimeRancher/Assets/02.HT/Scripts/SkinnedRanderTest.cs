using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinnedRanderTest : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        scale = new Vector3(2.0f, 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        skinnedMeshRenderer.transform.localScale = scale;
    }
}
