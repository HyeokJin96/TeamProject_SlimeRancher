using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_ : KSingleton<SceneManager_>
{
    public void Start()
    {
        GFunc.LoadScene(GData.SCENENAME_TITLE);
    }
}
