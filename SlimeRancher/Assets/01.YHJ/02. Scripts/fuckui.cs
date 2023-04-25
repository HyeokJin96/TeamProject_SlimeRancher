using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuckui : MonoBehaviour
{
    private string iconPath = "01.YHJ/Upgrade Station";

    [SerializeField] private Sprite[] loadedIcons = default;
    [SerializeField] private Image[] icons = default;

    private int childCount = default;

    private void Awake()
    {
        loadedIcons = Resources.LoadAll<Sprite>(iconPath);
        childCount = transform.childCount;
        icons = new Image[childCount];

        for (int i = 0; i < childCount; i++)
        {
            icons[i] = transform.GetChild(i).GetChild(0).GetComponent<Image>();

            if (i < loadedIcons.Length)
            {
                icons[i].sprite = loadedIcons[i];
            }
            else
            {
                return;
            }
        }
    }
}
