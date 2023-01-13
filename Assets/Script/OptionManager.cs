using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class OptionManager : MonoBehaviour
{
    public Image[] sushiImages;
    public GameObject sushiPanel;
    public Image setSushiImage;
    public Image setSaraImage;
    Image getSushiImage;
    public Image selectSushiImage;
    public TextMeshProUGUI sushiSelectText;

    //選択後の寿司パネル
    public GameObject selectedSushiPanel;
    public TextMeshProUGUI sushiSelectedText;
    public Image setSushiImage_2;


    public GameObject sushiBuyPanel;
    public Image buySushiImage;
    public TextMeshProUGUI sushiBuyText;
    public TextMeshProUGUI howMuchText;

    //購入後の寿司パネル
    public GameObject sushiBoughtPanel;
    public TextMeshProUGUI sushiBoughtText;
    public Image buySushiImage_2;

    //お金が足りない時のパネル
    public GameObject lackMoneyPanel;
    public TextMeshProUGUI lackMoneyText;
    public Image notBuySushiImage;

    public const int No_BOUGHT = 0;
    public const int BOUGHT = 1;
    SushiID selectedID;

    OptionSettingSushi selectedOptionSettingSushiID;

    public OptionSettingSushi defaultSushi;

    public static OptionManager instance;

    int currentMoney = 0;
    public TextMeshProUGUI curerntMoneyText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        PlayerPrefs.SetInt("BOUGHT_KEY"+ defaultSushi.sushiID,BOUGHT);
        PlayerPrefs.GetInt("BOUGHT_KEY" + defaultSushi.sushiID, BOUGHT);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SUSHI_IMAGE_ID"))
        {
            int sushiImageID = PlayerPrefs.GetInt("SUSHI_IMAGE_ID", 0);
            setSushiImage.sprite = SushiDataBaseSO.Entity.GetSushiData((SushiID)sushiImageID).sushiSprite;
            setSaraImage.sprite = SushiDataBaseSO.Entity.GetSushiData((SushiID)sushiImageID).saraSprite;
            
        }
        //最初は、パネル０
        panelNumber = Panel_0;

        Money.instance.Load();
         currentMoney = currentMoney + Money.instance.currentMoney;
        Debug.Log("現在のお金は？"+ Money.instance.currentMoney);
        //curerntMoneyText.text = currentMoney.ToString();
        curerntMoneyText.text = Money.instance.currentMoney.ToString();
    }

    public void ShowSushiPanel(SushiID sushiID)
    {
        selectedID = sushiID;
        //selectedSprite = sprite;
        SushiData sushiData = SushiDataBaseSO.Entity.GetSushiData(sushiID);
         //Debug.Log(sushiData.name);
        sushiSelectText.text = sushiData.name+"にしますか？";
        selectSushiImage.sprite = sushiData.sushiSprite;
        sushiPanel.SetActive(true);
    }

    SushiID keepID;

    public void ShowBuySushiPanel(SushiID sushiID,OptionSettingSushi optionSettingSushiID)
    {
        selectedOptionSettingSushiID = optionSettingSushiID; //取得
        selectedID = sushiID;
        SushiData sushiData = SushiDataBaseSO.Entity.GetSushiData(sushiID);
        sushiBuyText.text = sushiData.name + "を買いますか？";
        if (sushiData.sushiRank == SushiRank.Rank_1)
        {
            howMuchText.text = sushiRank_1 + "ゼニーをつかいます";
        }
        if (sushiData.sushiRank == SushiRank.Rank_2)
        {
            howMuchText.text = sushiRank_2 + "ゼニーをつかいます";
        }
        if (sushiData.sushiRank == SushiRank.Rank_3)
        {
            howMuchText.text = sushiRank_3 + "ゼニーをつかいます";
        }
        if (sushiData.sushiRank == SushiRank.Rank_4)
        {
            howMuchText.text = sushiRank_4 + "ゼニーをつかいます";
        }
        if (sushiData.sushiRank == SushiRank.Rank_5)
        {
            howMuchText.text = sushiRank_5 + "ゼニーをつかいます";
        }
        if (sushiData.sushiRank == SushiRank.Rank_6)
        {
            howMuchText.text = sushiRank_6 + "ゼニーをつかいます";
        }
        if (sushiData.sushiRank == SushiRank.Rank_7)
        {
            howMuchText.text = sushiRank_7 + "ゼニーをつかいます";
        }
        buySushiImage.sprite = sushiData.sushiSprite;
        sushiBuyPanel.SetActive(true);
        keepID = sushiID;
    }
    //寿司ランク1の消耗ゼニー
    public const int sushiRank_1 = 20;
    //寿司ランク2の消耗ゼニー
    public const int sushiRank_2 = 40;
    //寿司ランク3の消耗ゼニー
    public const int sushiRank_3 = 60;
    //寿司ランク4の消耗ゼニー
    public const int sushiRank_4 = 80;
    //寿司ランク5の消耗ゼニー
    public const int sushiRank_5 = 100;

    public const int sushiRank_6 = 150;

    public const int sushiRank_7 =  200;


    public void BuyButton()
    {
        
        //寿司データを取得して、keepIDを入れてから
        SushiData sushiData = SushiDataBaseSO.Entity.GetSushiData(keepID);
        //寿司ランク1なら
        if (Money.instance.currentMoney >= sushiRank_1 && sushiData.sushiRank == SushiRank.Rank_1)
        {
            Debug.Log("現在のお金" + currentMoney);
            currentMoney -= sushiRank_1; // -30は保存しなくてもいい
            selectedOptionSettingSushiID.ReturnColor(); // 使う
            BuySushiButton();
            PlayerPrefs.SetInt("BOUGHT_KEY" + selectedOptionSettingSushiID.sushiID, BOUGHT);
            Money.instance.buySushiCount += 1;
            //currentMoney = currentMoney + Money.instance.currentMoney;
            Money.instance.currentMoney -= sushiRank_1;
            curerntMoneyText.text = currentMoney.ToString();

            Debug.Log("減った金額" + sushiRank_1);
            Money.instance.Save();
            Debug.Log("保存した金額" + Money.instance.currentMoney);
            ShowBoughtSushiPanel();
            return;
        }
        //寿司ランク2なら
        if (Money.instance.currentMoney >= sushiRank_2 && sushiData.sushiRank == SushiRank.Rank_2)
        {
            Debug.Log("現在のお金" + currentMoney);
            currentMoney -= sushiRank_2; // -30は保存しなくてもいい
            selectedOptionSettingSushiID.ReturnColor(); // 使う
            BuySushiButton();
            PlayerPrefs.SetInt("BOUGHT_KEY" + selectedOptionSettingSushiID.sushiID, BOUGHT);
            Money.instance.buySushiCount += 1;
            //currentMoney = currentMoney + Money.instance.currentMoney;
            Money.instance.currentMoney -= sushiRank_2;
            curerntMoneyText.text = currentMoney.ToString();

            Debug.Log("減った金額" + sushiRank_2);
            Money.instance.Save();
            Debug.Log("保存した金額" + Money.instance.currentMoney);
            ShowBoughtSushiPanel();
            return;

        }
        //寿司ランク3なら
        if (Money.instance.currentMoney >= sushiRank_3 && sushiData.sushiRank == SushiRank.Rank_3)
        {
            Debug.Log("現在のお金" + currentMoney);
            currentMoney -= sushiRank_3; // -30は保存しなくてもいい
            selectedOptionSettingSushiID.ReturnColor(); // 使う
            BuySushiButton();
            PlayerPrefs.SetInt("BOUGHT_KEY" + selectedOptionSettingSushiID.sushiID, BOUGHT);
            Money.instance.buySushiCount += 1;
            //currentMoney = currentMoney + Money.instance.currentMoney;
            Money.instance.currentMoney -= sushiRank_3;
            curerntMoneyText.text = currentMoney.ToString();

            Debug.Log("減った金額" + sushiRank_3);
            Money.instance.Save();
            Debug.Log("保存した金額" + Money.instance.currentMoney);
            ShowBoughtSushiPanel();
            return;

        }
        if (Money.instance.currentMoney >= sushiRank_4 && sushiData.sushiRank == SushiRank.Rank_4)
        {
            Debug.Log("現在のお金" + currentMoney);
            currentMoney -= sushiRank_4; // -30は保存しなくてもいい
            selectedOptionSettingSushiID.ReturnColor(); // 使う
            BuySushiButton();
            PlayerPrefs.SetInt("BOUGHT_KEY" + selectedOptionSettingSushiID.sushiID, BOUGHT);
            Money.instance.buySushiCount += 1;
            //currentMoney = currentMoney + Money.instance.currentMoney;
            Money.instance.currentMoney -= sushiRank_4;
            curerntMoneyText.text = currentMoney.ToString();

            Debug.Log("減った金額" + sushiRank_4);
            Money.instance.Save();
            Debug.Log("保存した金額" + Money.instance.currentMoney);
            ShowBoughtSushiPanel();
            return;

        }
        if (Money.instance.currentMoney >= sushiRank_5 && sushiData.sushiRank == SushiRank.Rank_5)
        {
            Debug.Log("現在のお金" + currentMoney);
            currentMoney -= sushiRank_5; // -30は保存しなくてもいい
            selectedOptionSettingSushiID.ReturnColor(); // 使う
            BuySushiButton();
            PlayerPrefs.SetInt("BOUGHT_KEY" + selectedOptionSettingSushiID.sushiID, BOUGHT);
            Money.instance.buySushiCount += 1;
            //currentMoney = currentMoney + Money.instance.currentMoney;
            Money.instance.currentMoney -= sushiRank_5;
            curerntMoneyText.text = currentMoney.ToString();

            Debug.Log("減った金額" + sushiRank_5);
            Money.instance.Save();
            Debug.Log("保存した金額" + Money.instance.currentMoney);
            ShowBoughtSushiPanel();
            return;

        }
        if (Money.instance.currentMoney >= sushiRank_6 && sushiData.sushiRank == SushiRank.Rank_6)
        {
            Debug.Log("現在のお金" + currentMoney);
            currentMoney -= sushiRank_6; // -30は保存しなくてもいい
            selectedOptionSettingSushiID.ReturnColor(); // 使う
            BuySushiButton();
            PlayerPrefs.SetInt("BOUGHT_KEY" + selectedOptionSettingSushiID.sushiID, BOUGHT);
            Money.instance.buySushiCount += 1;
            //currentMoney = currentMoney + Money.instance.currentMoney;
            Money.instance.currentMoney -= sushiRank_6;
            curerntMoneyText.text = currentMoney.ToString();

            Debug.Log("減った金額" + sushiRank_6);
            Money.instance.Save();
            Debug.Log("保存した金額" + Money.instance.currentMoney);
            ShowBoughtSushiPanel();
            return;

        }
        if (Money.instance.currentMoney >= sushiRank_7 && sushiData.sushiRank == SushiRank.Rank_7)
        {
            Debug.Log("現在のお金" + currentMoney);
            currentMoney -= sushiRank_7; // -30は保存しなくてもいい
            selectedOptionSettingSushiID.ReturnColor(); // 使う
            BuySushiButton();
            PlayerPrefs.SetInt("BOUGHT_KEY" + selectedOptionSettingSushiID.sushiID, BOUGHT);
            Money.instance.buySushiCount += 1;
            //currentMoney = currentMoney + Money.instance.currentMoney;
            Money.instance.currentMoney -= sushiRank_7;
            curerntMoneyText.text = currentMoney.ToString();

            Debug.Log("減った金額" + sushiRank_7);
            Money.instance.Save();
            Debug.Log("保存した金額" + Money.instance.currentMoney);
            ShowBoughtSushiPanel();
            return;

        }
        //if (sushiData.sushiRank == SushiRank.Rank_1)
        //{
        //    Debug.Log("現在のお金" + currentMoney);
        //    currentMoney -= sushiRank_1; // -30は保存しなくてもいい
        //    selectedOptionSettingSushiID.ReturnColor(); // 使う
        //    BuySushiButton();
        //    PlayerPrefs.SetInt("BOUGHT_KEY" + selectedOptionSettingSushiID.sushiID, BOUGHT);
        //    Money.instance.buySushiCount += 1;
        //    //currentMoney = currentMoney + Money.instance.currentMoney;
        //    Money.instance.currentMoney -= sushiRank_1;
        //    curerntMoneyText.text = currentMoney.ToString();

        //    Debug.Log("減った金額" + sushiRank_1);
        //    Money.instance.Save();
        //    Debug.Log("保存した金額" + Money.instance.currentMoney);
        //    ShowBoughtSushiPanel();
        //}





        //全てに該当しない場合に、お金不足のパネルを出す。
        LackMoneyPanel();

        //}
    }

    void ShowBoughtSushiPanel()
    {
        sushiBuyPanel.SetActive(false);
        SushiData sushiData = SushiDataBaseSO.Entity.GetSushiData(keepID);
        sushiBoughtText.text = sushiData.name + "をえらべるようになった";
        buySushiImage_2.sprite = sushiData.sushiSprite;
        sushiBoughtPanel.SetActive(true);
    }
   
    void LackMoneyPanel()
    {
        SoundManager.instance.NotBuySE();
        sushiBuyPanel.SetActive(false);
        SushiData sushiData = SushiDataBaseSO.Entity.GetSushiData(keepID);
        lackMoneyText.text = sushiData.name + "はまだ買えません。";
        notBuySushiImage.sprite = sushiData.sushiSprite;
        lackMoneyPanel.SetActive(true);
    }

    public void CloseLackMoneyPanel()
    {
        lackMoneyPanel.SetActive(false);
    }

    public void CloseShowBoughtSushiPanel()
    {
        sushiBoughtPanel.SetActive(false);
        SoundManager.instance.TransitionSE();
    }

    public void NotBuyButton()
    {
        TransitionButton();
        sushiBuyPanel.SetActive(false);
    }

    public void DecideButton()
    {
        sushiPanel.SetActive(false);
        keepID = selectedID;
        ShowSelectedSushiPanel();
        setSushiImage.sprite = selectSushiImage.sprite;

        PlayerPrefs.SetInt("SUSHI_IMAGE_ID", (int)selectedID); //int,string,float 画像は保存できない

        //int sushiImageID = PlayerPrefs.GetInt("SUSHI_IMAGE_ID", 0);
        setSaraImage.sprite = SushiDataBaseSO.Entity.GetSushiData((SushiID)selectedID).saraSprite;

        DecideSushiButton();
       
        PlayerPrefs.Save();
    }

    void ShowSelectedSushiPanel()
    {
        SushiData sushiData = SushiDataBaseSO.Entity.GetSushiData(keepID);
        sushiSelectedText.text = sushiData.name + "で";
        setSushiImage_2.sprite = sushiData.sushiSprite;
        selectedSushiPanel.SetActive(true);
    }

    public void CloseShowSelectedSushiPanel()
    {
        selectedSushiPanel.SetActive(false);
        SoundManager.instance.TransitionSE();
    }

    public void NoDecideButton()
    {
        TransitionButton();
        sushiPanel.SetActive(false);
    }

    public void BackButton()
    {
        TransitionButton();
        SceneManager.LoadScene("Select");
        Money.instance.Save();
    }

    public GameObject panelParent;
    public const int Panel_0 = 1;
    public const int Panel_1 = 2;
    public const int Panel_2 = 3;
    public const int Panel_3 = 4;
    public const int Panel_4 = 5;


    int panelNumber;

    public void OnRightArrow()
    {
        TransitionButton();
        panelNumber++;
        if (panelNumber > Panel_4)
        {
            panelNumber = Panel_0;
        }
        DisPlaySushiPanel();
    }
     public void OnLeftArrow()
    {
        TransitionButton();
        panelNumber--;
        if (panelNumber < Panel_0)
        {
            panelNumber = Panel_4;
        }
        DisPlaySushiPanel();
    }

    void DisPlaySushiPanel()
    {
        //パネルをあと7個作って、case,breakをする
        switch (panelNumber)
        {
            case Panel_0:
                panelParent.transform.localPosition = new Vector2(0,0);
                break;
            case Panel_1:
                panelParent.transform.localPosition = new Vector2(-2000,0);
                break;
            case Panel_2:
                panelParent.transform.localPosition = new Vector2(-4000, 0);
                break;
            case Panel_3:
                panelParent.transform.localPosition = new Vector2(-6000, 0);
                break;
            case Panel_4:
                panelParent.transform.localPosition = new Vector2(-8000, 0);
                break;
        }
    }
    void TransitionButton()
    {
        SoundManager.instance.TransitionSE();
    }
    void BuySushiButton()
    {
        SoundManager.instance.BuySE();
    }
    void DecideSushiButton()
    {
        SoundManager.instance.DecideSushi();

    }
}
 