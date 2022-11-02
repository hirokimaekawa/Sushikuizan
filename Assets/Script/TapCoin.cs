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

    public Sprite maidoSprite;
    public Sprite defaultSprite;

    public void SwitchImage()
    {
        coinImage.sprite = maidoSprite;
    }

    //元に戻す関数
    public void ResetImage()
    {
        Debug.Log("ResetImageが実行された"); //実行された　ResetImageは呼び出しに成功
        coinImage.sprite = defaultSprite; //実行されてない　
        Debug.Log("ResetImageが実行された");
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
