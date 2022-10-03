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


    private enum LOGIN_TYPE
    {
        FIRST_USER_LOGIN, //初回ログイン
        TODAY_LOGIN,      //ログイン
        ALREADY_LOGIN,    //ログイン済
        ERROR_LOGIN       //不正ログイン
    }

    private int todayDate = 0;
    private int lastDate;
    private LOGIN_TYPE judge_type;

    private int dayCount;


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
                //なにもしない
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
        fisrtLoginPanel.SetActive(false);
    }

    public void ShowDairyLoginPanel()
    {
        diaryLoginPanel.SetActive(true);
    }

    //１日目、2日目と書かれたボタン
    public void TapDayButton()
    {
        ShowDairyLoginPanel();
    }

    public Sprite testSprite;

    public void DiaryBonusButton()
    {
        Money.instance.getMoney += 10;
        diaryLoginPanel.SetActive(false);
        Debug.Log(testSprite);
        TapCoin.instance.SwitchImage(testSprite);
        Debug.Log(testSprite);
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
}
