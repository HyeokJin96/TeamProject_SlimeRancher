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
        playerPos = GameObject.Find("Player").transform.position; // GameManager에서 받아올 것
        return playerPos;
    }

    public Quaternion GetRot()
    {
        playerRot = GameObject.Find("Player").transform.rotation; // GameManager에서 받아올 것
        return playerRot;
    }

    public Vector3 SetPos()
    {
        GameObject.Find("Player").transform.position = playerPos;
        return GameObject.Find("Player").transform.position;
    }

    public Quaternion SetRot()
    {
        GameObject.Find("Player").transform.rotation = playerRot;
        return GameObject.Find("Player").transform.rotation;
    }
}