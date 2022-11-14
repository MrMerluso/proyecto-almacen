using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrderManager : MonoBehaviour //este Script va asociado a un gameObject vacio que va a funcionar como manager de las ordenes y eventos
{

    public static OrderManager _instance = null; //ni idea como funcionan los singleton, pero los recomiendan para los managers

    public static List<OrderDetail> AllOrders = new List<OrderDetail>();
    public static List<string> ComlpetedOrders = new List<string>();
    public static List<string> FailedOrders = new List<string>();

    // Traté de hacerlo un singleton pero no funcionó
    public ClientManager ClientManager;

    // Esta es una forma horrible de hacer esto, pero han forzado mi mano
    public List<string> PorductNames;
    public List<float> ProductPrices;
    private int orderID = 1;


    public static float Money = 0;
    private float time = 0;
    private float newOrderTime = 5;

    public RectTransform Order;
    public RectTransform OrderQueue;


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

    public static void Restart()
    {
        AllOrders = new List<OrderDetail>();
        ComlpetedOrders = new List<string>();
        FailedOrders = new List<string>();
        Money = 0;
    }


    void Start(){
        InvokeRepeating("CreateOrder", 3.0f, newOrderTime);
    }

    // Creamos una orden con detalles al azar
    public void CreateOrder(){

        if (!ClientManager.CheckAvalibleSpawns())
        {
            return;
        }

        var OrderInstance = Instantiate(Order);
        var OrderData = new OrderDetail.OrderData();
        int rndIt = Random.Range(0, PorductNames.Count);

        OrderData._orderId = orderID++;
        OrderData._orderProduct = PorductNames[rndIt];
        OrderData._price = ProductPrices[rndIt];
        OrderData._orderTime = 30;

        
        OrderInstance.GetComponent<OrderDetail>()?.InitOrder(OrderData);
        ClientManager.SpawnClient(OrderInstance.GetComponent<OrderDetail>());

        OrderInstance.SetParent(OrderQueue);
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
    public static void CheckOrder(ItemDetail item)
    {

        
        foreach(OrderDetail od in AllOrders)
        {
            if(od._orderData._orderProduct == item.ProductName)
            {
                RemoveOrder(od);
                Destroy(item.gameObject);
                Destroy(od.gameObject);
                return;
            }
        }
    }
    public static int GetScore()
    {
        return (int)Money;
    }

/* 
    // Start is called before the first frame update
    void Start()
    {
        //condici�n para que empiece a generar ordenes (m�s adelante tiene que ser en el per�odo de recreos)
        StartGenerateOrders();
    }

    private void StartGenerateOrders()
    {
        StartCoroutine(GenerateOrder());
    }

    
    private IEnumerator GenerateOrder()
    {
        //condici�n para que empiece a generar ordenes (m�s adelante tiene que ser en el per�odo de recreos)
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
 */
}
