using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class test_btn : MonoBehaviour
{
    [SerializeField] private TMP_Text text = default;
    [SerializeField] private GameObject player = default;
    [SerializeField] private Player_Raycast player_Raycast = default;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        player_Raycast = player.GetComponent<Player_Raycast>();
        text = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (player_Raycast.isAppearing == true)
        {
            text.gameObject.SetActive(true);
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
