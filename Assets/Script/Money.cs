using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public static Money instance;
    public int getMoney;
    public int mushikuiPlayCount;
    public int sushikuiPlayCount;

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
    //string SEVEKEY = "SAVE-KEY";
    public void Save()
    {
        PlayerPrefs.SetInt("SAVE-KEY", getMoney);
        PlayerPrefs.SetInt("MushikuiKey", mushikuiPlayCount);
        PlayerPrefs.SetInt("SushikuiKey", sushikuiPlayCount);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        getMoney = PlayerPrefs.GetInt("SAVE-KEY", getMoney);
        mushikuiPlayCount = PlayerPrefs.GetInt("MushikuiKey", mushikuiPlayCount);
        sushikuiPlayCount = PlayerPrefs.GetInt("SushikuiKey", sushikuiPlayCount);
        //Debug.Log("kaunnto"+ sushikuiPlayCount);
    }
}
