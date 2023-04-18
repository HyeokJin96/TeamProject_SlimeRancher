using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeshRenderer : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderer = default;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            meshRenderer[i] = transform.GetChild(i).GetComponent<MeshRenderer>();
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
