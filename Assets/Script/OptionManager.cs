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


    SushiID selectedID;

    //Sprite selectedSprite;

    public static OptionManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSushiPanel(SushiID sushiID)
    {
        selectedID = sushiID;
        //selectedSprite = sprite;
        SushiData sushiData = SushiDataBaseSO.Entity.GetSushiData(sushiID);
        Debug.Log(sushiData.name);
        sushiSelectText.text = sushiData.name+"にしますか？";
        selectSushiImage.sprite = sushiData.sprite;
        sushiPanel.SetActive(true);
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
 