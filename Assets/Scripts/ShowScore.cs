using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    TMP_Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "$" + (int)OrderManager.GetScore();
    }
}
