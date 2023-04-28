using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitController : MonoBehaviour
{
    void Start()
    {
        //Init
        T_DataManager.Instance.Create();
        SoundManager.Instance.Create();
        SceneManager_.Instance.Create();
        GraphicsManager.Instance.Create();

        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        SceneManager_.Instance.GoTitleScene();
    }
}
