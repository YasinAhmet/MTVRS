using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cashUpdater : MonoBehaviour
{
    [SerializeField]
    private int cash = 100;

    public string firsttext;
    private Text text;

    private void Start()
    {
        text = this.GetComponent<Text>();
        firsttext = text.text;
    }

    void Update()
    {
        text.text = firsttext + cash;
    }

    public int getMoney()
    {
        return cash;
    }

    public void Expend(int money)
    {
        cash -= money;
    }

    public void Earn(int money)
    {
        cash += money;
    }
}
