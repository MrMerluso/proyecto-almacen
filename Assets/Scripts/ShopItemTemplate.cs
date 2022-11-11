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

    public void PurchaseItem()
    {
        Box.GetComponent<BoxController>().boxContent = BoxContent;
        Box.GetComponent<BoxController>().boxContentAmmount = 10;

        BoxSpawnPoint = GameObject.FindGameObjectWithTag("BoxSpawnPoint").transform;
        Box.transform.position = BoxSpawnPoint.position;

        Instantiate(Box);

    }
}
