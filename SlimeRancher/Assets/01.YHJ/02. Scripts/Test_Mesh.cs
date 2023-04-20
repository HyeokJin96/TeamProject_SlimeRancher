using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Mesh : MonoBehaviour
{
    public Mesh[] playerBodyMesh = default;

    public Mesh combinedMesh = default;

    private void Awake()
    {
        playerBodyMesh = new Mesh[12];

        for (int i = 0; i < 12; i++)
        {
            playerBodyMesh[i] = transform.GetChild(1).GetChild(i).GetChild(0).gameObject.GetComponent<MeshFilter>().mesh;
        }

        combinedMesh = new Mesh();

        CombineInstance[] combineInstances = new CombineInstance[playerBodyMesh.Length];

        for (int i = 0; i < playerBodyMesh.Length; i++)
        {
            combineInstances[i].mesh = playerBodyMesh[i];
            combineInstances[i].transform = transform.GetChild(1).GetChild(i).GetChild(0).transform.localToWorldMatrix;

        }
        combinedMesh.CombineMeshes(combineInstances);

        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();

        meshCollider.sharedMesh = combinedMesh;
    }

}
