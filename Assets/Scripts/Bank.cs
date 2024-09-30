using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    public float money;

    public TextMeshProUGUI moneyText;


    // Update is called once per frame
    void Update()
    {
        if (money > 1000000000)
        {
            moneyText.text = "$" + (money/1000000000).ToString("F3") + "B";
        }
        else if (money > 1000000)
        {
            moneyText.text = "$" + (money/1000000).ToString("F3") + "M";
        }
        else
        {
            moneyText.text = "$" + money.ToString("F2");
        }
    }
}
