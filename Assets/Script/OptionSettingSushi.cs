using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSettingSushi : MonoBehaviour
{

    //public static OptionSettingSushi instance;

    //Sprite sprite;
    public SushiID sushiID;

    public SushiData sushiData;

    [SerializeField]Image sushiImage;


    private void Awake()
    {
      
        //sprite = GetComponent<Image>().sprite;
        sushiImage = GetComponent<Image>();

        sushiImage.sprite = SushiDataBaseSO.Entity.GetSushiData(sushiID).sprite;
       
    }

    public void Start()
    {
        //違う方法で、boughtを判定し、該当する寿司を真っ黒にする。
        if ((PlayerPrefs.GetInt("BOUGHT_KEY" + sushiID, OptionManager.No_BOUGHT) == OptionManager.BOUGHT))
        {

        }
        else
        {
            sushiImage.color = Color.black;

        }
    }

    public void OnClick()
    {
        if ((PlayerPrefs.GetInt("BOUGHT_KEY" + sushiID, OptionManager.No_BOUGHT)==OptionManager.BOUGHT))
        {
            OptionManager.instance.ShowSushiPanel(sushiID);
        }
        else
        {
            OptionManager.instance.ShowBuySushiPanel(sushiID,this);
            
        }
    }

    //色を元に戻す関数を作った
    public void ReturnColor()
    {
        sushiImage.color = new Color(255, 255, 255);
    }
}
