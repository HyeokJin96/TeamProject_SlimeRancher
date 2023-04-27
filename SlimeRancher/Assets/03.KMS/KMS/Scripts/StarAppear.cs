using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAppear : MonoBehaviour
{
    private void Start()
    {
        transform.localEulerAngles = new Vector3(
            (-0.25f * (TimeController.Instance.minute 
            + (TimeController.Instance.hour * 60))),
            0,
            0
        );
    }
    private void Update() 
    {
        transform.Rotate(new Vector3(-0.25f, 0, 0) * Time.deltaTime
        * TimeController.Instance.nTimesFaster);
    }
}
