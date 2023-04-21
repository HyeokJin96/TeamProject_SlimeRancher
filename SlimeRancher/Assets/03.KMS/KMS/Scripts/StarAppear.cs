using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAppear : MonoBehaviour
{
    private void Update() 
    {
        transform.Rotate(new Vector3(-0.25f, 0, 0) * Time.deltaTime * 12); //6
    }
}
