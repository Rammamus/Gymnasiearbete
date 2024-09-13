using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Companies : MonoBehaviour
{
    public float bank;

    public float speed;
    float timer = 0;
    public float profit;
    public float price;
    public bool isPurchased;

    public TextMeshProUGUI priceText, timerText, profitText;
    public Slider progressSlider;

    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>().money;
        timer = speed;
        isPurchased = false;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPurchased)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                FindObjectOfType<Bank>().money += profit;
                timer = speed;
            }
            else
            {
                progressSlider.value = timer / speed;
                int seconds = Mathf.FloorToInt(timer);
                int milliseconds = Mathf.FloorToInt((timer - seconds) * 100);
                timerText.text = string.Format("{0:0}:{1:00}", seconds, milliseconds);
            }
        }
    }

    public void BuyCompany()
    {

        if (FindObjectOfType<Bank>().money - price >= 0)
        {
            if (!isPurchased)
            {
                isPurchased = true;
                FindObjectOfType<Bank>().money -= price;
                UpdateText();
            }
            else
            {
                price *= 1.2f;
                speed *= 0.8f;
                FindObjectOfType<Bank>().money -= price;
                UpdateText();
            }
        }
        
    }

    void UpdateText()
    {
        priceText.text = "$" + price.ToString("F2");
        profitText.text = "$" + profit.ToString();
    }
}
