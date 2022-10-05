using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{

    int totalMoney = 100;
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
        totalMoney = totalMoney + Money.instance.getMoney;
        curerntMoneyText.text = totalMoney.ToString(); //ゆくゆく残数のゼニーと通算獲得のゼニーを分けて考える必要がある

        mushikuiTotalPlayCount = mushikuiTotalPlayCount + Money.instance.mushikuiPlayCount;
        mushikuiPlayCountText.text = mushikuiTotalPlayCount + "回";

        sushikuiTotalPlayCount = sushikuiTotalPlayCount + Money.instance.sushikuiPlayCount;
        sushikuiPlayCountText.text = sushikuiTotalPlayCount+"回";
        buyTotalSushiCount = buyTotalSushiCount + Money.instance.buySushiCount;
        buyTotalSushiCountText.text = defautSushiCount + buyTotalSushiCount + "個";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BackButton()
    {
        SceneManager.LoadScene("Select");
    }
}

