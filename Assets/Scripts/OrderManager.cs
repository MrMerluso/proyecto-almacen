using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour //este Script va asociado a un gameObject vacio que va a funcionar como manager de las ordenes y eventos
{

    public static OrderManager _instance = null; //ni idea como funcionan los singleton, pero los recomiendan para los managers

    public static List<OrderDetail> AllOrders = new List<OrderDetail>();
    public static List<string> ComlpetedOrders = new List<string>();
    public static List<string> FailedOrders = new List<string>();

    public static List<GameObject> Clients;

    public static float Money = 0;


    public static void Restart()
    {
        AllOrders = new List<OrderDetail>();
        ComlpetedOrders = new List<string>();
        FailedOrders = new List<string>();
        Money = 0;
    }


    public static void MakeClients()
    {
        foreach (var client in Clients)
        {
            if (!client.activeInHierarchy)
            {
                client.GetComponent<ClientController>().TrySpawnClient("pedido");
            }
        }
    }
    public static void AddOrder(OrderDetail od)
    {
        AllOrders.Add(od);
    }
    public static void RemoveOrder(OrderDetail od, bool success = true)
    {
        AllOrders.Remove(od);
        if (success)
        {
            ComlpetedOrders.Add(od._orderData._orderProduct);
            Money += od._orderData._price;
        }
        else
        {
            FailedOrders.Add(od._orderData._orderProduct);
        }
    }
    public static void CheckOrder(string productName)
    {
        foreach(OrderDetail od in AllOrders)
        {
            if(od._orderData._orderProduct == productName)
            {
                RemoveOrder(od);
                Destroy(od.gameObject);
                return;
            }
        }
    }
    public static int GetScore()
    {
        return (int)Money;
    }
    private void Awake() 
    {
        if (_instance == null)
        {
            _instance = this;
        }else if(_instance !=this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //condición para que empiece a generar ordenes (más adelante tiene que ser en el período de recreos)
        StartGenerateOrders();
    }

    private void StartGenerateOrders()
    {
        StartCoroutine(GenerateOrder());
    }

    
    private IEnumerator GenerateOrder()
    {
        //condición para que empiece a generar ordenes (más adelante tiene que ser en el período de recreos)
        while (true)
        {
            yield return new WaitForSeconds(5); //cada x cantidad de segundos
            //Order = new OrderStruct();
            
            //ver como vincular la orden a un producto (hamburguesa) con OrderItem.cs
        }
    }

    public struct OrderStruct
    {
        
    }
}
