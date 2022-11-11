using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{

    public ShopManager ShopManager;

    private void OnTriggerEnter(Collider other)
    {
        ShopManager.Show();
    }

    private void OnTriggerExit(Collider other)
    {
        ShopManager.Hide();
    }
}
