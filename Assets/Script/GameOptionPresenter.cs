using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOptionPresenter : MonoBehaviour
{

    public GameObject soundPanel;
    public GameObject contactPanel;

    public Image OnBGMImage;
    public Image OffBGMImage;
    public Image OnSEImage;
    public Image OffSEImage;

    void Start()
    {
        if (PlayerPrefs.GetInt("BGM_KEY", GameOptionManager.OFF_BGM) == GameOptionManager.ON_BGM)
        {
            SetOnBGMButtonColor();
        }
        else
        {
            SetOffBGMButtonColor();
        }

        if (PlayerPrefs.GetInt("SE_KEY", GameOptionManager.OFF_SE) == GameOptionManager.ON_SE)
        {
            SetOnSEButtonColor();
        }
        else
        {
            SetOffSEButtonColor();
        }
    }

    public void SoundButton()
    {
        soundPanel.SetActive(true);
        TransitionButton();
    }

    public void BackSoundButton()
    {
        soundPanel.SetActive(false);
        TransitionButton();
    }
    public void HowPlayButton()
    {

    }

    public void ContactButton()
    {
        contactPanel.SetActive(true);
        TransitionButton();
    }
    public void BackContactButton()
    {
        contactPanel.SetActive(false);
        TransitionButton();
    }

    public void BackButton()
    {
        TransitionButton();
        SceneManager.LoadScene("Select");
    }

    public void OnBGMButton()
    {
        TransitionButton();
        SetOnBGMButtonColor();
        PlayerPrefs.SetInt("BGM_KEY", GameOptionManager.ON_BGM);
    }

    void SetOnBGMButtonColor()
    {
        OnBGMImage.color = new Color32(255, 192, 0, 255);
        OffBGMImage.color = new Color32(255, 255, 255, 255);
        SoundManager.instance.OnBGM();
    }
    //定数は、GameOptionManager.OFF_BGMで宣言できる
    public void OffBGMButton()
    {
        SetOffBGMButtonColor();
        PlayerPrefs.SetInt("BGM_KEY", GameOptionManager.OFF_BGM);
    }

    void SetOffBGMButtonColor()
    {
        OnBGMImage.color = new Color32(255, 255, 255, 255);
        OffBGMImage.color = new Color32(255, 192, 0, 255);
        SoundManager.instance.OffBGM();

    }

    public void OnSEButton()
    {
        SetOnSEButtonColor();
        TransitionButton();
        PlayerPrefs.SetInt("SE_KEY", GameOptionManager.ON_SE);

    }

    void SetOnSEButtonColor()
    {
        OnSEImage.color = new Color32(255, 192, 0, 255);
        OffSEImage.color = new Color32(255, 255, 255, 255);
        SoundManager.instance.OnSE();
    }


    public void OffSEButton()
    {
        SetOffSEButtonColor();
        PlayerPrefs.SetInt("SE_KEY", GameOptionManager.OFF_SE);

    }

    void SetOffSEButtonColor()
    {
        OnSEImage.color = new Color32(255, 255, 255, 255);
        OffSEImage.color = new Color32(255, 192, 0, 255);
        SoundManager.instance.OffSE();
    }

    void TransitionButton()
    {
        SoundManager.instance.TransitionSE();
    }

    public GameObject howPlayPanel;
    public GameObject image_1;
    public GameObject image_2;
    public GameObject image_3;
    public GameObject image_4;
    public GameObject image_5;
    public GameObject image_6;
    public GameObject image_7;


    public void ShowHowPlayPanelButton()
    {
        howPlayPanel.SetActive(true);
        image_1.SetActive(true);
        SoundManager.instance.TransitionSE();
    }

    public void SwitchHowPlayPanelButton_2()
    {
        image_1.SetActive(false);
        image_2.SetActive(true);
        SoundManager.instance.TransitionSE();
    }
    public void SwitchHowPlayPanelButton_3()
    {
        image_2.SetActive(false);
        image_3.SetActive(true);
        SoundManager.instance.TransitionSE();
    }
    public void SwitchHowPlayPanelButton_4()
    {
        image_3.SetActive(false);
        image_4.SetActive(true);
        SoundManager.instance.TransitionSE();

    }
    public void SwitchHowPlayPanelButton_5()
    {
        image_4.SetActive(false);
        image_5.SetActive(true);
        SoundManager.instance.TransitionSE();

    }
    public void SwitchHowPlayPanelButton_6()
    {
        image_5.SetActive(false);
        image_6.SetActive(true);
        SoundManager.instance.TransitionSE();

    }
    public void SwitchHowPlayPanelButton_7()
    {
        image_6.SetActive(false);
        image_7.SetActive(true);
        SoundManager.instance.TransitionSE();

    }
    public void SwitchHowPlayPanelButton_1()
    {
        image_7.SetActive(false);
        howPlayPanel.SetActive(false);
        SoundManager.instance.TransitionSE();

    }
}
