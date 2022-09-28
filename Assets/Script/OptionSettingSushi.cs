using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSettingSushi : MonoBehaviour
{

    //Sprite sprite;
    public SushiID sushiID;

    // Start is called before the first frame update
    private void Awake()
    {
        //sprite = GetComponent<Image>().sprite;
        GetComponent<Image>().sprite = SushiDataBaseSO.Entity.GetSushiData(sushiID).sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        OptionManager.instance.ShowSushiPanel(sushiID);
    }
}
