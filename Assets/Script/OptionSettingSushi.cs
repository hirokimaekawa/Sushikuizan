using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSettingSushi : MonoBehaviour
{

    public static OptionSettingSushi instance;

    //Sprite sprite;
    public SushiID sushiID;

    public SushiData sushiData;

    bool isBought;

    [SerializeField]Image sushiImage;


   
    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        //sprite = GetComponent<Image>().sprite;
        sushiImage = GetComponent<Image>();

        sushiImage.sprite = SushiDataBaseSO.Entity.GetSushiData(sushiID).sprite;

        if (!sushiData.bought)
        {
            
            sushiImage.color = Color.black;
        }
    }

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //// このif文を実行したい
        //if (sushiData.bought)
        //{
        //    //Debug.Log(sushiData.bought);
        //    sushiImage.color = new Color(255, 255, 255);
        //}
        ////あまり意味がない
        if (Input.GetKeyDown(KeyCode.A))
        {
            //    Debug.Log(sushiData.bought);
            OptionManager.instance.Test(optionSettingSushi);
        }

    }

    //自分自身を宣言して、自分自身をShowBuySushiPanelでOptionManagerに渡す
    public OptionSettingSushi optionSettingSushi;

    public void OnClick()
    {
        Debug.Log(sushiID);
        if (sushiData.bought)
        {
            OptionManager.instance.ShowSushiPanel(sushiID);
        }
        else
        {
            OptionManager.instance.ShowBuySushiPanel(sushiID,optionSettingSushi);
            
        }
    }

    public void ReturnColor(OptionSettingSushi optionSettingSushi)
    {
        sushiImage.color = new Color(255, 255, 255);
    }

    public void JudgeBuy(bool bought)
    {
        sushiData.bought = true;
    }
}
