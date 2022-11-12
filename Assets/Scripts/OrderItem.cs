using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderItem : MonoBehaviour
{

    public int _orderId; //para diferenciar de las otras ordenes
    public string _orderName; //el producto que pide la orden
    public bool _isServed = false; //bool para cachar si se sirvió la orden
    public bool _isExpired = false; //bool para cachar si la orden expiró

    private float _totalLifeTime = 60f; //tiempo que va a existir la orden
    public float _remainingTime; //auxiliar que va a tener el tiempo restante de cada orden

    //Events
    //public delegate void OrderTimerUpdate(float seconds);
    //public event OrderTimerUpdate OnOrderTimerUpdate;
    //public delegate void OrderExpired(OrderItem order);
    //public event OrderExpired OnExpired;

      //Debería existir una función con los distintos productos para generar pedidos distintos, 
        //como solo tenemos la hamburguesa vamos a trabajar con eso
     /*public void Setup(Product productOrder) 
    {
        _orderId = OrderManager.orderId;
        _orderName = OrderManager.orderName;
        //_recipeOrder = recipeOrder;
        SetTimer();  //Genera el contador de tiempo para la orden y luego la comienza
        StartTimer();
    }
     */
     



    private void SetTimer()
    {
        _remainingTime = _totalLifeTime;
    }

    private void StartTimer()
    {
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
            //OnOrderTimerUpdate?.Invoke(_remainingTime);
            yield return null;
            if(_isServed == true)
            {
                Debug.Log("La orden se realizó");
            }
        }
        Debug.Log("La orden expiró");
        _isExpired = true;
        
    }


}
