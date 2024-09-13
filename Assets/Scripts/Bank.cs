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
        moneyText.text = "$" + money.ToString("F2");
    }
}
