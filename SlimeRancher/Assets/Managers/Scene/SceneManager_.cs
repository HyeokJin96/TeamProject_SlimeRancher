using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_ : GSingleton<SceneManager_>
{
    public new void Start()
    {
        GFunc.LoadScene(GData.SCENENAME_TITLE);
    }
}
