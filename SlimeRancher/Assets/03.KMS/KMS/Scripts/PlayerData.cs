using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData
{
    public Vector3 playerPos = default;
    public Quaternion playerRot = default;

    public Vector3 GetPos()
    {
        playerPos = GameManager.Instance.playerPos;
        return playerPos;
    }

    public Quaternion GetRot()
    {
        playerRot = GameManager.Instance.playerRot;
        return playerRot;
    }

    public Vector3 SetPos()
    {
        GameManager.Instance.playerPos = playerPos;
        return GameManager.Instance.playerPos;
    }

    public Quaternion SetRot()
    {
        GameManager.Instance.playerRot = playerRot;
        return GameManager.Instance.playerRot;
    }
}