using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    //public GameObject box;
    public GameObject boxContent;
    public int boxContentAmmount;

    public GameObject TakeFromBox()
    {
        //if (boxContentAmmount > 1)
        //{
        //    boxContentAmmount--;
        //    var item = Instantiate(boxContent);
        //    item.GetComponent<PickupController>().SetAttributes();
        //    return item;
        //}
        //else
        //{
        //    Debug.Log($"There are no more things");
        //    Destroy(box);
        //    return null;

        //}
        var item = Instantiate(boxContent);
        // item.GetComponent<PickupController>().SetAttributes();
        boxContentAmmount--;
        if (boxContentAmmount < 1)
        {
            Destroy(gameObject);
        }
        return item;
    }
}
