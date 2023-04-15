using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : KSingleton<GameManager>
{
    public override void Init()
    {
        // GameManager의 초기화 작업을 수행합니다.
        Debug.Log("GameManager Initialized!");
    }

    public void StartGame()
    {
        // 게임 시작 시 수행되어야 할 작업을 처리합니다.
        Debug.Log("Game Started!");
    }
}
