using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlortMarketMachine : MonoBehaviour
{
    [SerializeField] public GameObject player;
    public int getPlortType;

    public int[] plortPrice;
    // Start is called before the first frame update
    void Start()
    {
        plortPrice = new int[] { 0, 10, 22, 22, 22, 45, 45, 45, 45, 45, 60, 60, 75, 60, 75, 75, 60, 300 };

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plort")
        {
            getPlortType = other.GetComponent<PlortBase>().plortType;
            //플레이어
            player.GetComponent<PlayerManager>().playerNewbucksCoin += plortPrice[getPlortType];
            other.gameObject.SetActive(false);
        }
    }
}
