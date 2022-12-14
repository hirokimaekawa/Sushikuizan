using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public static Money instance;
    public int getMoney;
    public int currentMoney;　// 最初に100与えられていて、この100ゼニーを基準に、足したり引いたりする
    public int mushikuiPlayCount;
    public int sushikuiPlayCount;

    public int buySushiCount;

    public int totalDayCount;

    //これを作らないと、Load（）を実行しても、インスタンスがないよって警告が出る
    private void Awake()
    {
      
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            Load();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

  
    public void FirstSave()
    {
        PlayerPrefs.SetInt("CURRENT_MONEY_KEY", getMoney);
    }
    public void DairyLoginSave()
    {
        PlayerPrefs.SetInt("CURRENT_MONEY_KEY", getMoney);
    }
    public void LastLoginSave()
    {
        PlayerPrefs.SetInt("CURRENT_MONEY_KEY", getMoney);
    }


    //string SEVEKEY = "SAVE-KEY";
    public void Save()
    {
        Debug.Log("実行された");
        PlayerPrefs.SetInt("SAVE-KEY", getMoney);
        PlayerPrefs.SetInt("CURRENT_MONEY_KEY",currentMoney);
        PlayerPrefs.SetInt("MushikuiKey", mushikuiPlayCount);
        PlayerPrefs.SetInt("SushikuiKey", sushikuiPlayCount);
        PlayerPrefs.SetInt("SUSHI_COUNT_KEY", buySushiCount);
        PlayerPrefs.SetInt("TOTAL_DAY_COUNT", totalDayCount);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        getMoney = PlayerPrefs.GetInt("SAVE-KEY", getMoney);
        currentMoney = PlayerPrefs.GetInt("CURRENT_MONEY_KEY", currentMoney);
        mushikuiPlayCount = PlayerPrefs.GetInt("MushikuiKey", mushikuiPlayCount);
        sushikuiPlayCount = PlayerPrefs.GetInt("SushikuiKey", sushikuiPlayCount);
        buySushiCount = PlayerPrefs.GetInt("SUSHI_COUNT_KEY", buySushiCount);
        totalDayCount = PlayerPrefs.GetInt("TOTAL_DAY_COUNT", totalDayCount);
        //Debug.Log("kaunnto"+ sushikuiPlayCount);
    }
}
