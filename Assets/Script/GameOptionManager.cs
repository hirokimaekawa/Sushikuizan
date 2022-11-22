using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOptionManager : MonoBehaviour
{

    public GameObject soundPanel;
    public GameObject contactPanel;

    public Image OnBGMImage;
    public Image OffBGMImage;
    public Image OnSEImage;
    public Image OffSEImage;

   
    public const int OFF_BGM = 0;
    public const int ON_BGM = 1;
   
    public const int OFF_SE = 0;
    public const int ON_SE = 1;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("BGM_KEY", OFF_BGM) == ON_BGM)
        {
            SetOnBGMButtonColorAndAction();
        }
        else
        {
            SetOffBGMButtonColorAndAction();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SetOnBGMButtonColorAndAction();
        PlayerPrefs.SetInt("BGM_KEY" , ON_BGM);
    }

    void SetOnBGMButtonColorAndAction()
    {
        OnBGMImage.color = new Color32(255, 192, 0, 255);
        OffBGMImage.color = new Color32(255, 255, 255, 255);
        SoundManager.instance.OnBGM();
    }
    public void OffBGMButton()
    {
        SetOffBGMButtonColorAndAction();
        PlayerPrefs.SetInt("BGM_KEY", OFF_BGM);
    }

    void SetOffBGMButtonColorAndAction()
    {
        OnBGMImage.color = new Color32(255, 255, 255, 255);
        OffBGMImage.color = new Color32(255, 192, 0, 255);
        SoundManager.instance.OffBGM();

    }

    public void OnSEButton()
    {
        OnSEImage.color = new Color32(255, 192, 0, 255);
        OffSEImage.color = new Color32(255, 255, 255, 255);
        SoundManager.instance.OnSE();
        TransitionButton();
    }
    public void OffSEButton()
    {
        OnSEImage.color = new Color32(255, 255, 255, 255);
        OffSEImage.color = new Color32(255, 192, 0, 255);
        SoundManager.instance.OffSE();
    }
    void TransitionButton()
    {
        SoundManager.instance.TransitionSE();
    }
}
