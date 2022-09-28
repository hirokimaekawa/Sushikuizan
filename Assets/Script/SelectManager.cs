using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectManager : MonoBehaviour
{

    int currentMoney = 100;
    public TextMeshProUGUI curerntMoneyText;

    // Start is called before the first frame update
    void Start()
    {
        Money.instance.Load();
        currentMoney = currentMoney + Money.instance.getMoney;
        curerntMoneyText.text = currentMoney.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMushikuizan()
    {
        SceneManager.LoadScene("Mushikuizan");
    }

    public void LoadSushikuizan()
    {
        SceneManager.LoadScene("Sushikuizan");
    }

    public void LoadOption()
    {
        SceneManager.LoadScene("Option");
    }
}
