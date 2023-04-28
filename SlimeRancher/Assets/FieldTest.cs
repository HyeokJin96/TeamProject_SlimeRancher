using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTest : MonoBehaviour
{
    public bool test;
    BoxCollider[] testCol_;
    // Start is called before the first frame update
    void Start()
    {
        testCol_ = GetComponents<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!test)
        {
            testCol_[0].enabled = true;
            testCol_[1].enabled = true;
        }
        else
        {
            testCol_[0].enabled = false;
            testCol_[1].enabled = false;
        }
    }
}
