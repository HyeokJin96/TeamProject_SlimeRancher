using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlortMarketScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D[] plortIcon;
    GameObject plortMarketMachine;
    bool isSetPrice;
    void Start()
    {
        plortIcon = Resources.LoadAll<Texture2D>("02.HT/Facilities/MarketScreen/Icon");
        plortMarketMachine = transform.parent.GetChild(1).gameObject;
        for (int i = 0; i < plortIcon.Length; i++)
        {

            transform.GetChild(i).GetComponent<MeshRenderer>().materials[1].SetTexture("_MainTexture", plortIcon[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetPrice();
    }
    void SetPrice()
    {
        if (!isSetPrice)
        {
            for (int i = 0; i < plortIcon.Length; i++)
            {
                transform.GetChild(i).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = plortMarketMachine.GetComponent<PlortMarketMachine>().plortPrice[i + 1].ToString();
                if (i == plortIcon.Length - 1)
                {
                    isSetPrice = true;
                }
            }
        }
    }
}
