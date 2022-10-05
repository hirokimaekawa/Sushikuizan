using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectManager : MonoBehaviour
{

    int totalMoney = 100;
    public TextMeshProUGUI  currentMoneyText;
    int curentMoney = 100;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("所持金" + Money.instance.currentMoney);
        Money.instance.Load();
        totalMoney = totalMoney + Money.instance.getMoney; //これまでの累積マネー

        curentMoney = curentMoney + Money.instance.currentMoney;
        currentMoneyText.text = curentMoney.ToString();
        Debug.Log("所持金" + Money.instance.currentMoney);
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
        SceneManager.LoadScene("SushiOption");
    }

    public void LoadReward()
    {
        SceneManager.LoadScene("Record");
    }
}
