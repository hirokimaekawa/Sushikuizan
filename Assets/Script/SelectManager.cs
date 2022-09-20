using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectManager : MonoBehaviour
{

    int currentMoney = 100;
    public TextMeshProUGUI curerntMoneyText;

    // Start is called before the first frame update
    void Start()
    {
        MushikuiMoney.instance.Load();
        currentMoney = currentMoney + MushikuiMoney.instance.getMoney;
        curerntMoneyText.text = currentMoney.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMushikuizan()
    {
        SceneManager.LoadScene("Mushikuizan");
    }
}
