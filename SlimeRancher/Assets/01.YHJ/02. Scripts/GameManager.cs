using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float mouseSensitivity = default;   //  ���콺 ����

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //  ���콺 Ŀ�� ����
    }
}
