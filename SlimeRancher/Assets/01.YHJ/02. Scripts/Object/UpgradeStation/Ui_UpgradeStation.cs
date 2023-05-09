using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

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

    [SerializeField] private GameObject ButtonList_Selected = default;
    [SerializeField] private Button[] button_Purchase = default;
    [SerializeField] private TMP_Text[] text_Purchase = default;

    private bool isSold;

    [SerializeField] private PlayerManager playerManager = default;

    private void OnEnable()
    {
        listButton[0].Select();
    }

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

        ButtonList_Selected = transform.GetChild(1).GetChild(2).GetChild(1).gameObject;
        button_Purchase = new Button[ButtonList_Selected.transform.childCount];
        text_Purchase = new TMP_Text[ButtonList_Selected.transform.childCount];

        playerManager = player.GetComponent<PlayerManager>();

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

        for (int i = 0; i < button_Purchase.Length; i++)
        {
            button_Purchase[i] = ButtonList_Selected.transform.GetChild(i).GetComponent<Button>();
            text_Purchase[i] = button_Purchase[i].transform.GetChild(0).GetComponent<TMP_Text>();

            button_Purchase[i].gameObject.SetActive(false);
            text_Purchase[i].text = "Purchase";
        }

        listButton[5].gameObject.SetActive(false);

        listButton[8].gameObject.SetActive(false);
        listButton[9].gameObject.SetActive(false);
        listButton[10].gameObject.SetActive(false);

        listButton[12].gameObject.SetActive(false);
        listButton[13].gameObject.SetActive(false);

        listButton[15].gameObject.SetActive(false);
        listButton[16].gameObject.SetActive(false);
        listButton[17].gameObject.SetActive(false);



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

                button_Purchase[i].gameObject.SetActive(true);
            }
            else
            {
                button_Purchase[i].gameObject.SetActive(false);
            }
        }
    }

    public void onClicked(Button clickedButton_)
    {
        for (int i = 0; i < text_Purchase.Length; i++)
        {
            if (button_Purchase[i] == clickedButton_)
            {
                if (playerManager.playerNewbucksCoin >= int.Parse(selected_Cost))
                {
                    switch (selected_Name)
                    {
                        case "Slime Key":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            // [KMS] Add Have Key 230508
                            GameManager.Instance.isHaveKey = true;
                            // [KMS] Add Have Key 230508
                            break;
                        case "Water Tank":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            break;
                        case "Jetpack":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.hasJetpack = true;
                            break;
                        case "Air Drive":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerJetpackConsumption *= 0.8f;
                            break;
                        case "Dash Boots":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerPowerConsumption *= 0.8f;
                            listButton[5].gameObject.SetActive(true);
                            break;
                        case "Ultra Dash Boots":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerPowerConsumption *= 0.8f;
                            break;
                        case "Pulse Wave":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            break;
                        case "Heart Module":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerMaxHealth += 50;
                            listButton[8].gameObject.SetActive(true);
                            break;
                        case "Heart Module Mk2":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerMaxHealth += 50;
                            listButton[9].gameObject.SetActive(true);
                            break;
                        case "Heart Module Mk3":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerMaxHealth += 50;
                            listButton[10].gameObject.SetActive(true);
                            break;
                        case "Heart Module Ultra":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerMaxHealth += 50;
                            break;
                        case "Power Core":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerMaxEnergy += 50;
                            playerManager.playerEnergyincrease *= 1.5f;
                            listButton[12].gameObject.SetActive(true);
                            break;
                        case "Power Core Mk2":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerMaxEnergy += 50;
                            playerManager.playerEnergyincrease *= 1.5f;
                            listButton[13].gameObject.SetActive(true);
                            break;
                        case "Power Core Mk3":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerMaxEnergy += 50;
                            playerManager.playerEnergyincrease *= 1.5f;
                            break;
                        case "Tank Booster":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerStorageSpace += 10;
                            listButton[15].gameObject.SetActive(true);
                            break;
                        case "Tank Booster Mk2":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerStorageSpace += 10;
                            listButton[16].gameObject.SetActive(true);
                            break;
                        case "Tank Booster Mk3":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerStorageSpace += 10;
                            listButton[17].gameObject.SetActive(true);
                            break;
                        case "Tank Booster Ultra":
                            listButton[i].interactable = false;
                            playerManager.playerNewbucksCoin -= int.Parse(selected_Cost);
                            playerManager.playerStorageSpace += 100;
                            break;
                    }
                    clickedButton_.interactable = false;
                    text_Purchase[i].text = "Sold Out";
                }
                else
                {
                    Debug.Log("������ ����");
                }



            }
        }
    }
}