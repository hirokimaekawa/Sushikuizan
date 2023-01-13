using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{
    int totalLoginDays = 0;
    public TextMeshProUGUI totalLoginDaysText;

    int totalMoney = 0;
    public TextMeshProUGUI curerntMoneyText;

    int mushikuiTotalPlayCount;
    public TextMeshProUGUI mushikuiPlayCountText;

    int sushikuiTotalPlayCount;
    public TextMeshProUGUI sushikuiPlayCountText;

    int buyTotalSushiCount;
    const int defautSushiCount = 1;

    public TextMeshProUGUI buyTotalSushiCountText;



    // Start is called before the first frame update
    void Start()
    {
        Money.instance.Load();
        totalLoginDays = totalLoginDays + Money.instance.totalDayCount;
        totalLoginDaysText.text = totalLoginDays.ToString();


        totalMoney = totalMoney + Money.instance.getMoney;
        curerntMoneyText.text = totalMoney.ToString(); //ゆくゆく残数のゼニーと通算獲得のゼニーを分けて考える必要がある

        mushikuiTotalPlayCount = mushikuiTotalPlayCount + Money.instance.mushikuiPlayCount;
        mushikuiPlayCountText.text = mushikuiTotalPlayCount.ToString();

        sushikuiTotalPlayCount = sushikuiTotalPlayCount + Money.instance.sushikuiPlayCount;
        sushikuiPlayCountText.text = sushikuiTotalPlayCount.ToString();
        buyTotalSushiCount = buyTotalSushiCount + Money.instance.buySushiCount;
        buyTotalSushiCountText.text = defautSushiCount + buyTotalSushiCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BackButton()
    {
        TransitionButton();
        SceneManager.LoadScene("Select");
    }
    void TransitionButton()
    {
        SoundManager.instance.TransitionSE();
    }
}

