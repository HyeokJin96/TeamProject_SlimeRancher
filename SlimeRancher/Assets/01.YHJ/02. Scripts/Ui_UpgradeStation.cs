using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_UpgradeStation : MonoBehaviour
{
    private string resourcePath_UpgradeStation = "01.YHJ/Upgrade Station";
    private string resourcePath_Text = "01.YHJ/TextAsset/Name";

    [SerializeField] private Sprite[] loadedIcons = default;
    [SerializeField] TextAsset textAsset = default;

    [SerializeField] private GameObject upgradeList = default;

    [SerializeField] private Image[] icons = default;
    [SerializeField] private TMP_Text[] text = default;
    [SerializeField] private string[] lines = default;


    private void Awake()
    {
        loadedIcons = Resources.LoadAll<Sprite>(resourcePath_UpgradeStation);
        textAsset = Resources.Load<TextAsset>(resourcePath_Text);

        upgradeList = transform.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;

        icons = new Image[18];
        text = new TMP_Text[18];
        lines = textAsset.text.Split('\n');

        for (int i = 0; i < icons.Length; i++)
        {
            icons[i] = upgradeList.transform.GetChild(i).GetChild(0).GetComponent<Image>();

            if (i < loadedIcons.Length)
            {
                icons[i].sprite = loadedIcons[i];
            }
            else
            {
                return;
            }
        }

        for (int i = 0; i < text.Length; i++)
        {
            text[i] = upgradeList.transform.GetChild(i).GetChild(1).GetComponent<TMP_Text>();

            if (i < lines.Length)
            {
                text[i].text = lines[i].Trim();
            }
        }


    }
}