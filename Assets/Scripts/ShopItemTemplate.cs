using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItemTemplate : MonoBehaviour
{
    public TMP_Text ItemName;
    public TMP_Text ItemPrice;
    public GameObject Box;
    public GameObject BoxContent;
    public Transform BoxSpawnPoint;

    private AudioSource purchaseSound;

    void Awake()
    {
        purchaseSound = GameObject.FindGameObjectWithTag("PurchaseSound").GetComponent<AudioSource>();
    }

    public void PurchaseItem()
    {
        
        if (int.Parse(ItemPrice.text) > (int)OrderManager.Money)
        {
            return;
        }

        Box.GetComponent<BoxController>().boxContent = BoxContent;
        Box.GetComponent<BoxController>().boxContentAmmount = 6;
        Box.GetComponent<BoxController>().boxText.text = ItemName.text;

        BoxSpawnPoint = GameObject.FindGameObjectWithTag("BoxSpawnPoint").transform;
        Box.transform.position = BoxSpawnPoint.position;
        OrderManager.Money -= float.Parse(ItemPrice.text);

        purchaseSound.Play();

        Instantiate(Box);

    }
}
