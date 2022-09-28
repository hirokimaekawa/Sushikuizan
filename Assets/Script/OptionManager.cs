using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public Image[] sushiImages;
    public GameObject sushiPanel;
    public Image setSushiImage;
    Image getSushiImage;
    public Image selectSushiImage;

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
        //getSushiImage = GetComponent<Image>();
        if (PlayerPrefs.HasKey("SUSHI_IMAGE_ID"))
        {
            int sushiImageID = PlayerPrefs.GetInt("SUSHI_IMAGE_ID", 0);
            Debug.Log("あ"+sushiImageID);
            Debug.Log("い" + (SushiID)sushiImageID);
            setSushiImage.sprite = SushiDataBaseSO.Entity.GetSushiData((SushiID)sushiImageID).sprite;
        }
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
}
