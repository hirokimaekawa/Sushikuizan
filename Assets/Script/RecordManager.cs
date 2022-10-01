using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{

    int currentMoney = 100;
    public TextMeshProUGUI curerntMoneyText;

    // Start is called before the first frame update
    void Start()
    {
        Money.instance.Load();
        currentMoney = currentMoney + Money.instance.getMoney;
        curerntMoneyText.text = currentMoney.ToString(); //ゆくゆく残数のゼニーと通算獲得のゼニーを分けて考える必要がある
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BackButton()
    {
        SceneManager.LoadScene("Select");
    }
}

