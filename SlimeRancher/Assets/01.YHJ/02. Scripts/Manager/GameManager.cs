using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float mouseSensitivity = default;   //  마우스 감도

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //  마우스 커서 고정
    }
}
