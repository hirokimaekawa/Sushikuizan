using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public static Money instance;
    public int getMoney;
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
    string SEVEKEY = "SEVE-KEY";
    public void Save()
    {
        PlayerPrefs.SetInt(SEVEKEY, getMoney);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        getMoney = PlayerPrefs.GetInt(SEVEKEY, getMoney);
    }
    //[SerializeField]
    //public class JsonModel
    //{
    //    [SerializeField] int currentMoney;
    //}
}
