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
            setSushiImage.sprite = SushiDataBaseSO.Entity.GetSushiData((SushiID)sushiImageID).sprite;
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
        selectSushiImage.sprite = sushiData.sprite;
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
        buySushiImage.sprite = sushiData.sprite;
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

    public void BuyButton()
    {
        sushiBuyPanel.SetActive(false);
        ShowBoughtSushiPanel();
        if (Money.instance.currentMoney > 20)
        {
            //寿司データを取得して、keepIDを入れてから
            SushiData sushiData = SushiDataBaseSO.Entity.GetSushiData(keepID);
            //寿司ランク1なら
            if (sushiData.sushiRank == SushiRank.Rank_1)
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
            }
            //寿司ランク2なら
            if (sushiData.sushiRank == SushiRank.Rank_2)
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
            }
            //寿司ランク3なら
            if (sushiData.sushiRank == SushiRank.Rank_3)
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
            }

        }
    }

    void ShowBoughtSushiPanel()
    {
        SushiData sushiData = SushiDataBaseSO.Entity.GetSushiData(keepID);
        sushiBoughtText.text = sushiData.name + "をえらべるようになった";
        buySushiImage_2.sprite = sushiData.sprite;
        sushiBoughtPanel.SetActive(true);
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
        DecideSushiButton();
        PlayerPrefs.SetInt("SUSHI_IMAGE_ID",(int)selectedID); //int,string,float 画像は保存できない
        PlayerPrefs.Save();
    }

    void ShowSelectedSushiPanel()
    {
        SushiData sushiData = SushiDataBaseSO.Entity.GetSushiData(keepID);
        sushiSelectedText.text = sushiData.name + "で";
        setSushiImage_2.sprite = sushiData.sprite;
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
    int panelNumber;

    public void OnRightArrow()
    {
        TransitionButton();
        panelNumber++;
        if (panelNumber > Panel_2)
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
            panelNumber = Panel_2;
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
 