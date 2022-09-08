using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Mushikuizan : MonoBehaviour
{

    int leftNumber;
    int rightNumber;
    int sumNumber;

    public TextMeshProUGUI textMeshProUGUI_0;
    public TextMeshProUGUI textMeshProUGUI_1;
    public TextMeshProUGUI textMeshProUGUI_2;
    public TextMeshProUGUI textMeshProUGUI_3;
    public TextMeshProUGUI textMeshProUGUI_4;
    public TextMeshProUGUI textMeshProUGUI_5;
    public TextMeshProUGUI textMeshProUGUI_6;
    public TextMeshProUGUI textMeshProUGUI_7;
    public TextMeshProUGUI textMeshProUGUI_8;
    public TextMeshProUGUI textMeshProUGUI_9;
    public TextMeshProUGUI textMeshProUGUI_10;

    // Start is called before the first frame update
    void Start()
    {
        CreateQuestion();
        ExtractTextInt();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void CreateQuestion()
    {
        //SystemとUnityEngineの両方があると、Random.Rangeは衝突して使えなくなる
        sumNumber = UnityEngine.Random.Range(1,11); // 答えは、１〜１０までの数字をランダムで抽出する
        Debug.Log(sumNumber);
        leftNumber = UnityEngine.Random.Range(0, sumNumber+1); //左の数字は、０〜sumNumner+1まで
        Debug.Log(leftNumber);
        rightNumber = sumNumber - leftNumber; //右の数字は、sumNumberからleftNumberを引いて求める
        Debug.Log(rightNumber);
    }

    void CheckAnswer()
    {
        //０〜１０までのボタンにそれぞれ、０〜１０のint型の整数として識別するには、どうしたら良いのか？

        //if (rightNumber = )
        //{

        //}
    }
    void ExtractTextInt()
    {
        //Debug.Log(textMeshProUGUI_0.text);
        string x = textMeshProUGUI_0.text;
        int y = Convert.ToInt32(x);
        Debug.Log(y.GetType());
        Debug.Log(y);
    }

}
