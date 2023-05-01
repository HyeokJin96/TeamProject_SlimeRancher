using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Ui_UpgradeStation : MonoBehaviour
{
    private string resourcePath_Sprite = "01.YHJ/Upgrade Station";
    private string resourcePath_TextAsset = "01.YHJ/TextAsset/Ui_UpgradeStation";

    [SerializeField] private Canvas canvs = default;

    [SerializeField] private Sprite[] loadedIcons = default;
    [SerializeField] private TextAsset loadedText = default;

    [SerializeField] private GameObject upgradeList = default;
    [SerializeField] private GameObject Information = default;

    [SerializeField] private Image[] itemIconImages = default;

    [SerializeField] private TMP_Text[] itemNameTexts = default;
    [SerializeField] private TMP_Text[] itemInformationTexts = default;
    [SerializeField] private TMP_Text[] itemCostTexts = default;

    [SerializeField] private string[] lines = default;

    [SerializeField] public string[] itemNameCandidates = default;
    [SerializeField] public string[] itemInformationCandidates = default;
    [SerializeField] public string[] itemCostCandidates = default;

    [SerializeField] public Button[] listButton;
    [SerializeField] private Sprite selected_Icon;
    [SerializeField] private string selected_Name;
    [SerializeField] private string selected_Information;
    [SerializeField] private string selected_Cost;

    [SerializeField] private GameObject player = default;
    [SerializeField] private Player_Raycast player_Raycast = default;

    private void Awake()
    {
        loadedIcons = Resources.LoadAll<Sprite>(resourcePath_Sprite);
        loadedText = Resources.Load<TextAsset>(resourcePath_TextAsset);

        canvs = transform.parent.GetComponent<Canvas>();

        player = GameObject.FindWithTag("Player");
        player_Raycast = player.GetComponent<Player_Raycast>();

        upgradeList = transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        Information = transform.GetChild(1).GetChild(2).GetChild(0).gameObject;

        itemIconImages = new Image[upgradeList.transform.childCount];

        itemNameTexts = new TMP_Text[upgradeList.transform.childCount];
        itemInformationTexts = new TMP_Text[upgradeList.transform.childCount];
        itemCostTexts = new TMP_Text[upgradeList.transform.childCount];

        listButton = new Button[upgradeList.transform.childCount];

        itemNameCandidates = new string[upgradeList.transform.childCount];
        itemInformationCandidates = new string[upgradeList.transform.childCount];
        itemCostCandidates = new string[upgradeList.transform.childCount];

        lines = loadedText.text.Split('\n');

        for (int i = 0; i < itemIconImages.Length; i++)
        {
            itemIconImages[i] = upgradeList.transform.GetChild(i).GetChild(0).GetComponent<Image>();
            listButton[i] = upgradeList.transform.GetChild(i).GetComponent<Button>();

            if (i < loadedIcons.Length)
            {
                itemIconImages[i].sprite = loadedIcons[i];
            }
            else
            {
                return;
            }
        }

        for (int i = 0; i < itemNameTexts.Length; i++)
        {
            string[] index = lines[i].Trim().Split('/');
            itemNameTexts[i] = upgradeList.transform.GetChild(i).GetChild(1).GetComponent<TMP_Text>();

            itemNameCandidates[i] = index[0].Trim();
            itemInformationCandidates[i] = index[1].Trim();
            itemCostCandidates[i] = index[2].Trim();

            itemNameTexts[i].text = itemNameCandidates[i];
        }

        listButton[0].Select();
        listButton[0].onClick.Invoke();
    }

    public void OnButtonClicked(Button clickedButton_)
    {
        for (int i = 0; i < listButton.Length; i++)
        {
            if (listButton[i] == clickedButton_)
            {
                selected_Icon = listButton[i].transform.GetChild(0).GetComponent<Image>().sprite;

                selected_Name = itemNameCandidates[i];
                selected_Information = itemInformationCandidates[i];
                selected_Cost = itemCostCandidates[i];

                Information.transform.GetChild(0).GetComponent<Image>().sprite = selected_Icon;
                Information.transform.GetChild(1).GetComponent<TMP_Text>().text = selected_Name;
                Information.transform.GetChild(2).GetComponent<TMP_Text>().text = selected_Information;
                Information.transform.GetChild(3).GetComponent<TMP_Text>().text = "Cost :\t" + selected_Cost;
            }
        }
    }
}