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
    public GameObject sushiBuyPanel;
    public Image buySushiImage;
    public TextMeshProUGUI sushiBuyText;

    public const int No_BOUGHT = 0;
    public const int BOUGHT = 1;
    SushiID selectedID;

    OptionSettingSushi selectedOptionSettingSushiID;

    public OptionSettingSushi defaultSushi;

    public static OptionManager instance;

    int currentMoney = 100;
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
        Debug.Log("現在のお金は？"+currentMoney);
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

    public void ShowBuySushiPanel(SushiID sushiID,OptionSettingSushi optionSettingSushiID)
    {
        selectedOptionSettingSushiID = optionSettingSushiID; //取得
        selectedID = sushiID;
        SushiData sushiData = SushiDataBaseSO.Entity.GetSushiData(sushiID);
        sushiBuyText.text = sushiData.name + "を買いますか？";
        buySushiImage.sprite = sushiData.sprite;
        sushiBuyPanel.SetActive(true);
    }

    public const int normalSushi = 30;
    //public bool isBought = false;
    public void BuyButton()
    {
        sushiBuyPanel.SetActive(false);
        if (Money.instance.currentMoney > 20)
        {
            Debug.Log("現在のお金"+currentMoney);
            //currentMoney -= normalSushi; // -30は保存しなくてもいい
            selectedOptionSettingSushiID.ReturnColor();　// 使う
            PlayerPrefs.SetInt("BOUGHT_KEY"+selectedOptionSettingSushiID.sushiID,BOUGHT);
            Money.instance.buySushiCount += 1;
            //currentMoney = currentMoney + Money.instance.currentMoney;
            Money.instance.currentMoney -= normalSushi;
            curerntMoneyText.text = currentMoney.ToString();
           
            Debug.Log("減った金額"+ normalSushi);
            Money.instance.Save();
            Debug.Log("保存した金額"+Money.instance.currentMoney);
        }
    }

    public void NotBuyButton()
    {
        sushiBuyPanel.SetActive(false);
    }

    public void DecideButton()
    {
        sushiPanel.SetActive(false);
        setSushiImage.sprite = selectSushiImage.sprite;
        PlayerPrefs.SetInt("SUSHI_IMAGE_ID",(int)selectedID); //int,string,float 画像は保存できない
        PlayerPrefs.Save();
    }

    public void NoDecideButton()
    {
        sushiPanel.SetActive(false);
    }

    public void BackButton()
    {
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
        panelNumber++;
        if (panelNumber > Panel_2)
        {
            panelNumber = Panel_0;
        }
        DisPlaySushiPanel();
    }
     public void OnLeftArrow()
    {
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
}
 