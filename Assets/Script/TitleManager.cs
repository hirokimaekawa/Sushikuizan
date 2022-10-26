using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public GameObject loginPanel;
    public GameObject fisrtLoginPanel;
    public GameObject diaryLoginPanel;
    public GameObject lastLoginPanel;
    public GameObject fisrtBonusButton;
    public GameObject goSelectButton;


    public enum LOGIN_TYPE
    {
        FIRST_USER_LOGIN, //初回ログイン
        TODAY_LOGIN,      //ログイン
        ALREADY_LOGIN,    //ログイン済
        ERROR_LOGIN       //不正ログイン
    }

    private int todayDate = 0;
    private int lastDate;
    public LOGIN_TYPE judge_type;

    private int dayCount;

    public static TitleManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        DateTime now = DateTime.Now;//端末の現在時刻の取得        
        todayDate = now.Year * 10000 + now.Month * 100 + now.Day;//日付を数値化　2020年9月1日だと20200901になる

        //前回ログイン時の日付データをロード データがない場合はFIRST_USER_LOGINで0
        lastDate = PlayerPrefs.GetInt("LastGetDate", (int)LOGIN_TYPE.FIRST_USER_LOGIN);
        dayCount = PlayerPrefs.GetInt("LastestDay",dayCount);


        //前回と今回の日付データ比較

        if (lastDate < todayDate)//日付が進んでいる場合
        {
            judge_type = LOGIN_TYPE.TODAY_LOGIN; // 今日初めてログインするよ
            dayCount++;
        }
        else if (lastDate == todayDate)//日付が進んでいない場合
        {
            judge_type = LOGIN_TYPE.ALREADY_LOGIN;　 // 今日はもうログインしたよ
        }
        else if (lastDate > todayDate)//日付が逆転している場合
        {
            judge_type = LOGIN_TYPE.ERROR_LOGIN;　// エラーだよ
        }
    }

    public const int NO_LOGIN = 0;
    public const int LOGIN = 1;

    private void JudgeBonusType()
    {
        switch (judge_type)
        {
            //ログインボーナス
            case LOGIN_TYPE.TODAY_LOGIN:

                //初ログインボーナス　lastDateに0が入っていたら処理実行
                if (lastDate == (int)LOGIN_TYPE.FIRST_USER_LOGIN)
                {
                    ShowFirstLoginPanel();
                }
                else
                {

                    //普通のログインボーナス処理
                  
                }
                // 10日目のログインなら、特別な200ゼニープレゼント、dayCountの実装をする
                if (dayCount == 10)
                {
                    ShowLastLoginPanel();
                }


                break;

            //すでにログイン済み
            case LOGIN_TYPE.ALREADY_LOGIN:
                //次に進むボタンを出す
                goSelectButton.SetActive(true);
                break;

            //不正ログイン
            case LOGIN_TYPE.ERROR_LOGIN:
                //不正ログイン時の処理
                break;
        }

        //今回取得した日付をセーブ
        PlayerPrefs.SetInt("LastGetDate", todayDate);
        PlayerPrefs.SetInt("LastestDay",dayCount);
        PlayerPrefs.Save();
    }
    //応用して、ログインデータを保存する
    //ログインした、してない　public const int NO_LOGIN = 0; public const int LOGIN =  1;

    //PlayerPrefs.SetInt("BOUGHT_KEY"+selectedOptionSettingSushiID.sushiID,BOUGHT);

    public void StratButton()
    {
        //SceneManager.LoadScene("Select");
        loginPanel.SetActive(true);
        JudgeBonusType();
    }

    void ShowFirstLoginPanel()
    {
        fisrtLoginPanel.SetActive(true);
    }

    public void FisrtBonusButton()
    {
        Money.instance.getMoney += 100; //まず、プレゼントで  100ゼニーをあげる
        Money.instance.currentMoney += 100;
        //Money.instance.FirstSave();
        fisrtLoginPanel.SetActive(false);
        Debug.Log("１回目"+Money.instance.getMoney);
    }

    public void ShowDairyLoginPanel(TapCoin tapCoin)
    {
        Debug.Log($"{tapCoin.tapCoinDay}:{dayCount}");
        if ((int)tapCoin.tapCoinDay == dayCount-1)
        {
            diaryLoginPanel.SetActive(true);
            //引数のthisをtapCoinで受け取ってtapCoinIDに入れた
            tapCoinID = tapCoin;
        }
       
    }

    TapCoin tapCoinID;

    public void DiaryBonusButton()
    {
        Money.instance.getMoney += 10;
        Money.instance.currentMoney += 10;

        diaryLoginPanel.SetActive(false);
        //tapCoinIDを使ってSwitchImageを参照する
        tapCoinID.SwitchImage();
        goSelectButton.SetActive(true);
        PlayerPrefs.SetInt("LOGIN_KEY" + tapCoinID.tapCoinDay, LOGIN);
        //Money.instance.DairyLoginSave();
        Debug.Log("２回目" + Money.instance.getMoney);
        Debug.Log("２回目" + Money.instance.currentMoney);

    }

    public void ShowLastLoginPanel()
    {
        lastLoginPanel.SetActive(true);
    }

    public void LastBonusButton()
    {
        Money.instance.getMoney += 200;
        lastLoginPanel.SetActive(false);
    }

    public void GoToSelect()
    {
        SceneManager.LoadScene("Select");
        Money.instance.Save();
    }
}
