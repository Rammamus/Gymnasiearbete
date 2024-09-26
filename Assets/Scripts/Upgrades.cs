using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public float cost;
    public TextMeshProUGUI upgradeText, costText;

    public Companies company;

    // Start is called before the first frame update
    void Start()
    {
        upgradeText.text = "Permanently double " + company + " profits";
        costText.text = "$" + cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        if (FindObjectOfType<Bank>().money - cost >= 0)
        {
            company.profit *= 2f;
            company.profitGain *= 2f;
            FindObjectOfType<Bank>().money -= cost;
            company.UpdateText();
        }
    }
}
