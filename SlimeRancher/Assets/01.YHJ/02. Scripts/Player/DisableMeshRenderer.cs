using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeshRenderer : MonoBehaviour
{
    [SerializeField] private GameObject body = default;
    [SerializeField] private MeshRenderer[] meshRenderer = default;

    private void Awake()
    {
        body = transform.GetChild(1).gameObject;

        for (int i = 0; i < body.transform.childCount; i++)
        {
            meshRenderer[i] = body.transform.GetChild(i).GetComponent<MeshRenderer>();
        }
    }

    private void Start()
    {
        foreach (MeshRenderer meshrenderer_ in meshRenderer)
        {
            meshrenderer_.enabled = false;
        }
    }
}
