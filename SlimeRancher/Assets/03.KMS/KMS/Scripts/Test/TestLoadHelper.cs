using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoadHelper : MonoBehaviour
{
    public Vector3 playerPos_ = default;
    public Quaternion playerRot_ = default;

    void Start()
    {
        if (T_DataManager.Instance.isLoadOn == true)
        {
            playerPos_ = T_DataManager.Instance.playerdata_.playerPos_;
            playerRot_ = T_DataManager.Instance.playerdata_.playerRot_;

            GameManager.Instance.player.transform.position = playerPos_;
            GameManager.Instance.player.transform.rotation = playerRot_;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            T_DataManager.Instance.playerdata_.playerPos_ = GameManager.Instance.player.transform.position;
            T_DataManager.Instance.playerdata_.playerRot_ = GameManager.Instance.player.transform.rotation;

            Debug.Log(GameManager.Instance.player.transform.position);
            Debug.Log(GameManager.Instance.player.transform.rotation);
        }
    }
}
