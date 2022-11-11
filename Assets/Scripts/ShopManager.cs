using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public RectTransform PanelContents;
    public RectTransform ItemTemplate;
    public ShopItemSO[] ShopItemSO;

    
    void Awake()
    {
        LoadItems();
    }


    public void Show(){
        gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LoadItems()
    {
        foreach (var item in ShopItemSO)
        {
            var itemTemplate = Instantiate(ItemTemplate);
            var itemTemplateInfo = itemTemplate.GetComponent<ShopItemTemplate>();

            itemTemplateInfo.ItemName.text = item.itemName.ToString();
            itemTemplateInfo.ItemPrice.text = item.itemPrice.ToString();
            itemTemplateInfo.Box = item.Box;
            itemTemplateInfo.BoxContent = item.BoxContents;

            itemTemplate.SetParent(PanelContents);
            itemTemplate.transform.localScale = Vector3.one;
        }
    }



    
}
