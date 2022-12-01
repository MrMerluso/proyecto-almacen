using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //condici?n para que empiece a generar ordenes (m?s adelante tiene que ser en el per?odo de recreos)
        StartGenerateOrders();
    }

    private void StartGenerateOrders()
    {
        StartCoroutine(GenerateEvent());
    }


    private IEnumerator GenerateEvent()
    {
        //condici?n para que empiece a generar ordenes (m?s adelante tiene que ser en el per?odo de recreos)
        while (true)
        {
            yield return new WaitForSeconds(5); //cada x cantidad de segundos
            Debug.Log("evento");
                                                

            //ver como vincular la orden a un producto (hamburguesa) con OrderItem.cs
        }
    }



}
