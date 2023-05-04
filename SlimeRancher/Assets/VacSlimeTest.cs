using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacSlimeTest : MonoBehaviour
{
    public GameObject rootSlime;
    // Start is called before the first frame update
    void Start()
    {
        rootSlime = transform.parent.parent.parent.parent.parent.parent.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
