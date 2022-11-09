using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectManager : MonoBehaviour
{

    int totalMoney = 0;
    public TextMeshProUGUI  currentMoneyText;
    int curentMoney = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("所持金" + Money.instance.currentMoney);
        Money.instance.Load();
        totalMoney = totalMoney + Money.instance.getMoney; //これまでの累積マネー
        curentMoney = curentMoney + Money.instance.getMoney;

        currentMoneyText.text = Money.instance.currentMoney.ToString();
        Debug.Log("所持金" + Money.instance.currentMoney);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMushikuizan()
    {
        TransitionButton();
        SceneManager.LoadScene("Mushikuizan");
    }

    public void LoadSushikuizan()
    {
        TransitionButton();
        SceneManager.LoadScene("Sushikuizan");
    }

    public void LoadOption()
    {
        TransitionButton();
        SceneManager.LoadScene("SushiOption");
    }

    public void LoadReward()
    {
        TransitionButton();
        SceneManager.LoadScene("Record");
    }

    public void LoadGameOption()
    {
        TransitionButton();
        SceneManager.LoadScene("GameOption");
    }

    void TransitionButton()
    {
        SoundManager.instance.TransitionSE();
    }
}
