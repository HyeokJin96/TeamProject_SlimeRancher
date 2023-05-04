using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testclick : MonoBehaviour
{
    bool isclick = false;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isclick = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isclick = false;
        }

        if (Input.GetMouseButton(0))
        {
            if (isclick) 
            { 
                StartCoroutine(tetest());
            }
        }
    }

    IEnumerator tetest()
    {
        Debug.Log("shoot");
        isclick = false;
        yield return new WaitForSeconds(0.7f);
        isclick = true;
    }
}
