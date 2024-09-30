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
    public float profit, profitGain;
    public float price;
    public bool isPurchased;
    public int amount;

    public bool canUseTimer;

    public TextMeshProUGUI priceText, timerText, profitText, amountText;
    public Slider progressSlider, amountSlider;

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
                if (canUseTimer)
                {
                    progressSlider.value = timer / speed;
                    int minutes = Mathf.FloorToInt(timer / 60);
                    int seconds = Mathf.FloorToInt(timer);
                    int milliseconds = Mathf.FloorToInt((timer - seconds) * 100);
                    timerText.text = string.Format("{0:0}:{1:00}:{2:00}", minutes, seconds, milliseconds);
                }
                else if (!canUseTimer)
                {
                    progressSlider.value = progressSlider.minValue;
                    timerText.text = "0:00";
                }
            }
        }
    }

    public void BuyCompany()
    {

        if (FindObjectOfType<Bank>().money - price < 0)
        {
            return;
        }
        else
        {
            if (!isPurchased)
            {
                isPurchased = true;
                canUseTimer = true;
                FindObjectOfType<Bank>().money -= price;
            }
            else
            {
                FindObjectOfType<Bank>().money -= price;
                price *= 1.08f;
                profit += profitGain;
            }
            amount++;
            UpdateText();
            if (amount >= amountSlider.maxValue)
            {
                amountSlider.minValue = amount;
                amountSlider.maxValue = amount + 10;
                speed *= 0.6f;
            }
            if (speed <= 0.05f)
            {
                speed = 0.05f;
                canUseTimer = false;
            }
        }
    }

    public void UpdateText()
    {
        if (price >= 1000000000)
        {
            priceText.text = "$" + (price / 1000000000).ToString("F3") + "B";
        }
        else if (price >= 1000000)
        {
            priceText.text = "$" + (price/1000000).ToString("F3") + "M";
        }
        else
        {
            priceText.text = "$" + price.ToString("F2");
        }

        if (profit >= 1000000000)
        {
            profitText.text = "$" + (price / 1000000000).ToString("F3") + "B";
        }
        else if (profit >= 1000000)
        {
            profitText.text = "$" + (profit/1000000).ToString("F3") + "M";
        }
        else
        {
            profitText.text = "$" + profit.ToString("F2");
        }

        amountText.text = amount.ToString();

        amountSlider.value = amount;
    }
}
