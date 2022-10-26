using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapCoin : MonoBehaviour
{
    Image coinImage;

    public TapCoinID tapCoinDay;

    // Start is called before the first frame update
    void Start()
    {
        coinImage = GetComponent<Image>();

        if ((PlayerPrefs.GetInt("LOGIN_KEY"+tapCoinDay, TitleManager.NO_LOGIN) == TitleManager.LOGIN))
        {
            //ログインされているなら、画像を差し替える
            SwitchImage();
        }
        else
        {
           //ログインされていないなら、何もしない
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite MaidoSprite;
    public void SwitchImage()
    {
        coinImage.sprite = MaidoSprite;
    }

    public void TapDayButton()
    {
       
        //ログインボーナスをゲット済なら
        if ((PlayerPrefs.GetInt("LOGIN_KEY" + tapCoinDay, TitleManager.NO_LOGIN) == TitleManager.LOGIN))
        {

        }
        else
        {
            TitleManager.instance.ShowDairyLoginPanel(this);
        }
        //ログインボーナスをまだゲットしていないなら

    }

}
