using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_ : KSingleton<SceneManager_>
{
    public void GoTitleScene()
    {
        GFunc.LoadScene(GData.SCENENAME_TITLE);
    }

    public void GoPlayScene()
    {
        UIManager.Instance.isPlayMenu_Open = false;
        GFunc.LoadScene(GData.SCENENAME_PLAY);
    }

    
}
