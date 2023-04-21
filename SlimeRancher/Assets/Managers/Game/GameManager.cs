using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : KSingleton<GameManager> // [KMS] 0421 add Singleton
{
    // [KMS] 0421 add caching player
    public GameObject player = default;
    public Vector3 playerPos = default;
    public Quaternion playerRot = default;

    PlayerData playerData_ = new PlayerData();


    // [KMS] 0421 add caching player

    [SerializeField]
    public float mouseSensitivity = default; //  ���콺 ����

    // [KMS] 0421 add caching player
    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerPos = player.transform.position;
            playerRot = player.transform.rotation;

            playerData_.playerPos = playerPos;
            playerData_.playerRot = playerRot;
        }
    }
    // [KMS] 0421 add caching player
}
