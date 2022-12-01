using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndGameScreen : MonoBehaviour
{
    public TMP_Text gameOverDetail;
    void Start()
    {
        string totalOrders = "Lograste realizar "+ OrderManager.ComlpetedOrders.Count+" pedidos\n";
        string totalMoney = "Generaste " + OrderManager.totalMoney + " dólares\n";
        string totalTime = "Duraste " + OrderManager.timer.ToString("0") + " segundos";
        string textFinal = totalOrders + totalMoney + totalTime;
        gameOverDetail.text = textFinal;
        OrderManager.Restart();
    }

}
