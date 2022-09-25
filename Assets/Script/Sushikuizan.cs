using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sushikuizan : MonoBehaviour
{
    int leftNumber;
    int rightNumber;
    int sumNumber;

    public TextMeshProUGUI sumNumberText;
    public TextMeshProUGUI leftNumberText;
    public TextMeshProUGUI rightNumberText;

    [SerializeField] SushiTana leftSushiTuna;
    [SerializeField] SushiTana sumSushiTuna;
    [SerializeField] DragSushiTana rightSushiTana;
    public DragSushiTana dragSushiTana;

    public Image[] dragSushiImages;

    // Start is called before the first frame update
    void Start()
    {
        CreateQuestion();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateQuestion()
    { 
        //SystemとUnityEngineの両方があると、Random.Rangeは衝突して使えなくなる
        sumNumber = UnityEngine.Random.Range(1, 11); // 答えは、１〜１０までの数字をランダムで抽出する
        //Debug.Log(sumNumber);
        sumNumberText.text = sumNumber.ToString();
        sumSushiTuna.SetSushiImages(sumNumber);
        leftNumber = UnityEngine.Random.Range(0, sumNumber+1); ; //左の数字は、０〜sumNumner+1まで⇨右辺だけでなく、左辺も10になったら、テキストが黒板からはみ出すからsumNumberにした
        //Debug.Log(leftNumber);
        leftNumberText.text = leftNumber.ToString();
        leftSushiTuna.SetSushiImages(leftNumber);
        rightNumber = sumNumber - leftNumber; //右の数字は、sumNumberからleftNumberを引いて求める
        Debug.Log(rightNumber);
        rightNumberText.text = rightNumber.ToString();
        rightSushiTana.SetSushiImages(0);
    }

    void SetLeftSushi(int sushi)
    {
        //ここでは、引数分の寿司を表示する
    }

    public void AnwserButton()
    {
        if (dragSushiTana.count == rightNumber)
        {
            Debug.Log("正解！！");
            CreateQuestion();
            ResetDragSushi();
        }
        else
        {
            Debug.Log("不正解");
            ResetDragSushi();
            rightSushiTana.SetSushiImages(0);
        }

    }

    public void ResetDragSushi()
    {
        for (int i = 0; i < dragSushiImages.Length; i++)
        {
            dragSushiImages[i].gameObject.SetActive(true);
            dragSushiImages[i].gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true; //わからないけどやらないと一旦フォルスにしたら、blocksRaycastsがオフになってしまう。⇨だからここでやる

        }
    }

    public void ResetButton()
    {

    }
}
