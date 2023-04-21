using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitController : MonoBehaviour
{
    void Start()
    {
        DataManager.Instance.Create();
        SoundManager.Instance.Create();
        SceneManager_.Instance.Create();
        GraphicsManager.Instance.Create();

        SceneManager_.Instance.GoTitleScene();
    }
}
