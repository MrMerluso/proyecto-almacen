using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderDetail : MonoBehaviour
{
    [System.Serializable]
    public class OrderData
    {
        public int _orderId; //para diferenciar de las otras ordenes
        public string _orderProduct; //el producto que pide la orden
        public float _price; //precio del producto
        public float _orderTime; //tiempo en que se cancela la orden
    }
    public OrderData _orderData = new OrderData();

    public bool _isServed; //bool para cachar si se sirvi� la orden
    public bool _isExpired; //bool para cachar si la orden expir�
    public float _Timer;

    public TMP_Text OrderIDText;
    public TMP_Text OrderProductText;
    public TMP_Text TimeLeftText;
    // Start is called before the first frame update
    void Start()
    {
        // InitOrder(_orderData);
        OrderManager.AddOrder(this);
    }

    public void InitOrder(OrderData newData)
    {
        _orderData._orderId = newData._orderId;
        OrderIDText.text = _orderData._orderId.ToString();
        OrderProductText.text = _orderData._orderProduct = newData._orderProduct;
        _orderData._price = newData._price;
        _orderData._orderTime = newData._orderTime;
        _isExpired = false;
        _isServed = false;
        _Timer = newData._orderTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isServed)
        {
            return;
        }
        if (_Timer > 0)
        {
            _Timer -= Time.deltaTime;
            if (_Timer <= 0)
            {
                _isExpired = true;
                OrderManager.RemoveOrder(this, false);
                Destroy(gameObject);
            }
            else
            {
                TimeLeftText.text = ((int)_Timer).ToString();
            }
        }

    }
}
