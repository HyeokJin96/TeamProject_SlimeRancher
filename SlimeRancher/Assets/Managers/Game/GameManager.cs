using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : KSingleton<GameManager> 
{
    public GameObject player = default;
    public Vector3 playerPos = default;
    public Quaternion playerRot = default;

    PlayerData playerData_ = new PlayerData();

    [SerializeField]
    public float mouseSensitivity = default; //  ���콺 ����
}
