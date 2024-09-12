using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Companies : MonoBehaviour
{
    public float bank;

    public float speed;
    float timer = 0;
    public float profit;
    public float price;
    public bool isPurchased;

    public TextMeshProUGUI priceText, timerText, profitText;

    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>().money;
        isPurchased = false;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPurchased)
        {
            timer += Time.deltaTime;

            if (timer >= speed)
            {
                bank += profit;
                timer = 0;
            }
        }
    }

    public void Buy()
    {
        price *= 1.2f;
        speed *= 0.8f;
    }

    void UpdateText()
    {
        Debug.Log("OSSAAAAAHHHH");
        priceText.text = "$" + price.ToString();
        profitText.text = "$" + profit.ToString();
    }
}
