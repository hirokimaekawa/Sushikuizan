using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Image[] sushiImages;
    public GameObject sushiPanel;
    public Image setSushiImage;
    Image getSushiImage;
    public Image selectSushiImage;

    // Start is called before the first frame update
    void Start()
    {
        getSushiImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSushiPanel()
    {
        sushiPanel.SetActive(true);
    }

    public void DecideButton()
    {
        sushiPanel.SetActive(false);
        //マグロのImageのSpriteを取得する
        getSushiImage.sprite = //this.gameObject.GetComponent<Image>().sprite;(左は間違いなので、ここを考え中です)
        //取得したSpriteをselectSushiImageに置き換える
        selectSushiImage.sprite = getSushiImage.sprite;
        //取得したSpriteをに置き換える
        setSushiImage.sprite = getSushiImage.sprite;
    }

    public void NoDecideButton()
    {
        sushiPanel.SetActive(false);
    }
}
