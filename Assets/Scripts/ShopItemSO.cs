using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Items/ShopItem")]
public class ShopItemSO : ScriptableObject
{
    public string itemName;
    public int itemPrice;
    
    public GameObject Box;
    public GameObject BoxContents;
}
