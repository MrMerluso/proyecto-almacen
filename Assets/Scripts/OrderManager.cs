using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public static float totalMoney = 0;
    private float time = 0;
    private static float newOrderTime = 5;
    public static float orderTime = 30;
    // cantidad máxima de clientes a spawnear
    public static int clientMaxWaveSize = 99;
    // Cantidad de clientes que se encuentran actualmente en el mapa
    public static int currentWaveSize = 0;

    public RectTransform Order;
    public RectTransform OrderQueue;
    public TMP_Text WelcomeText;

    public static float timer = 0;
    static bool isRunning = true;
    


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
        newOrderTime = 5;
        orderTime = 30;
        Money = 0;
        totalMoney = 0;
        timer = 0;
    }


    void Start(){
        StartCoroutine(CreateOrder());
        StartCoroutine(RampingDifficulty());
        StartCoroutine(RemoveWelcomeText());
    }

    private void Update()
    {
        
        if (FailedOrders.Count == 3)
        {
            isRunning = false;
            SceneManager.LoadScene(3);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (isRunning)
        {
            timer += Time.deltaTime;
        }
    }

    private IEnumerator RemoveWelcomeText()
    {
        yield return new WaitForSeconds(7f);
        WelcomeText.gameObject.SetActive(false);
    }

    private IEnumerator RampingDifficulty()
    {
        yield return new WaitForSeconds(75f);
        newOrderTime = 4;
        orderTime = 26;
        yield return new WaitForSeconds(250f);
        newOrderTime = 3;
        orderTime = 23;
        
    }

    // Creamos una orden con detalles al azar
    public IEnumerator CreateOrder(){

        // if (!ClientManager.CheckAvalibleSpawns())
        // {
        //     return;
        // }

        yield return new WaitForSeconds(15f);

        while (true)
        {
            yield return new WaitForSeconds(newOrderTime);
            
            Debug.Log("Tring to create an order...");

        

            var OrderInstance = Instantiate(Order);
            var OrderData = new OrderDetail.OrderData();
            int rndIt = Random.Range(0, PorductNames.Count);

            OrderData._orderId = orderID++;
            OrderData._orderProduct = PorductNames[rndIt];
            OrderData._price = ProductPrices[rndIt];
            OrderData._orderTime = orderTime;

            
            OrderInstance.GetComponent<OrderDetail>()?.InitOrder(OrderData);
            ClientManager.SpawnClient(OrderInstance.GetComponent<OrderDetail>());

            currentWaveSize++;

            OrderInstance.SetParent(OrderQueue);
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
            totalMoney += od._orderData._price;
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

}
