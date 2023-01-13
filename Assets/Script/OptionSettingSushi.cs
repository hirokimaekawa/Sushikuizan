using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSettingSushi : MonoBehaviour
{

    //public static OptionSettingSushi instance;

    //Sprite sprite;
    public SushiID sushiID;


    //public SaraID saraID;

    public SushiData sushiData;

    [SerializeField]Image sushiImage;


    private void Awake()
    {
        sushiImage = GetComponent<Image>();
        sushiImage.sprite = SushiDataBaseSO.Entity.GetSushiData(sushiID).sushiSprite;  
    }

    public void Start()
    {

        //例えば、マグロIDの購入保存データを参照する
        if ((PlayerPrefs.GetInt("BOUGHT_KEY" + sushiID, OptionManager.No_BOUGHT) == OptionManager.BOUGHT))
        {
            //左辺のOptionManager.BOUGHT(つまり、１)と右辺のOptionManager.BOUGHT（つまり、１）だと、何もしない
        }
        else
        {
            //イコールにならないから、黒になる
            sushiImage.color = Color.black;
        }

        
        //if ((PlayerPrefs.GetInt("BOUGHT_KEY" + sushiID, OptionManager.No_BOUGHT) == OptionManager.BOUGHT))
        //{

        //}
        //else
        //{
        //    sushiImage.color = Color.black;
        //}



    }


    //クリックしたタイミングで、SushiDataのSushiRankを渡す仕組みを作る必要があるかも、そのためにOptionManagerで引数ありの関数を作る必要がある。
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
