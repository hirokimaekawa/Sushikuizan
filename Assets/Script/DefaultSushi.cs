using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultSushi : MonoBehaviour
{

    void Awake()
    {
        if (PlayerPrefs.HasKey("SUSHI_IMAGE_ID"))
        {
            int sushiImageID = PlayerPrefs.GetInt("SUSHI_IMAGE_ID", 0);
            Debug.Log(sushiImageID);
            Debug.Log((SushiID)sushiImageID);
            GetComponent<Image>().sprite = SushiDataBaseSO.Entity.GetSushiData((SushiID)sushiImageID).sushiSprite;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
