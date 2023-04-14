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
        GFunc.LoadScene(GData.SCENENAME_PLAY);
    }

    public void test_()
    {
        if (
            SceneManager.GetActiveScene().name == GData.SCENENAME_PLAY
            && Input.GetKeyDown(KeyCode.Tab)
        )
        {
            GoTitleScene();
        }
    }

    private void Update()
    {
        test_();
    }
}
