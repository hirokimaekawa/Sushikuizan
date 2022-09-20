using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class Mushikuizan : MonoBehaviour
{
    public static Mushikuizan instance;

    int leftNumber;
    int rightNumber;
    int sumNumber;

    int questionCount; // デフォルトで20とかにしておいて、設定で変えれるようにする
    //public int getMoney;

    public TextMeshProUGUI sumNumberText;
    public TextMeshProUGUI leftNumberText;
    public TextMeshProUGUI rightNumberText;
    public GameObject squareText;　　//Textだけど、GameObject型で取得した
    public GameObject answerImage;
    public GameObject finishPanel;
    public GameObject backPanel;
    

    AudioSource audioSource;
    public AudioClip correctSE;
    public AudioClip incorrectSE;
    public AudioClip successSE;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CreateQuestion();
         //ExtractTextInt();
    }

    // Update is called once per frame
    void Update()
    {
        Finish();
    }

    bool isCalledOnce = false;
    void Finish()
    {
        if (questionCount == 10 && isCalledOnce ==false)
        {
            finishPanel.SetActive(true);
            MushikuiMoney.instance.getMoney += 10;
            audioSource.PlayOneShot(successSE);  //Updateに入っているから、ずっと鳴りっぱなし。
            isCalledOnce = true;
        }
    }

    void CreateQuestion()
    {
        Init();
        //SystemとUnityEngineの両方があると、Random.Rangeは衝突して使えなくなる
        sumNumber = UnityEngine.Random.Range(1,11); // 答えは、１〜１０までの数字をランダムで抽出する
        //Debug.Log(sumNumber);
        sumNumberText.text = sumNumber.ToString();
        leftNumber = UnityEngine.Random.Range(0, sumNumber); //左の数字は、０〜sumNumner+1まで⇨右辺だけでなく、左辺も10になったら、テキストが黒板からはみ出すからsumNumberにした
        //Debug.Log(leftNumber);
        leftNumberText.text = leftNumber.ToString();
        rightNumber = sumNumber - leftNumber; //右の数字は、sumNumberからleftNumberを引いて求める
        Debug.Log(rightNumber);
    }
    

    IEnumerator appearAnwser()
    {
        if (questionCount < 9)
        {
            ShowCorrectSE();
            squareText.SetActive(false);
            rightNumberText.text = rightNumber.ToString();
            answerImage.SetActive(true);
            questionCount++;
            Debug.Log("カウントは"+ questionCount);
            yield return new WaitForSeconds(1.0f);
            CreateQuestion();
        }
        else
        {
            ShowCorrectSE();
            squareText.SetActive(false);
            rightNumberText.text = rightNumber.ToString();
            answerImage.SetActive(true);
            questionCount++;
            Debug.Log(" 最後のカウントは" + questionCount);
        }
        
    }

    void Init()
    {
        squareText.SetActive(true);
        rightNumberText.text = "";
        answerImage.SetActive(false);
    }

    void Reset()
    {
        questionCount = 0;
        isCalledOnce = false; //一回だけ呼び出すために bool配置
        CreateQuestion();
    }

    //void ExtractTextInt()
    //{
    //    //Debug.Log(textMeshProUGUI_0.text);
    //    string x = textMeshProUGUI_0.text;
    //    int y = Convert.ToInt32(x);
    //    Debug.Log(y.GetType());
    //    Debug.Log(y);
    //}

    void ShowCorrectSE()
    {
        audioSource.PlayOneShot(correctSE);
    }

    void ShowInCorrectSE()
    {
        audioSource.PlayOneShot(incorrectSE);
    }

    public void SelectNumber_0()
    {
        int number = 0;
        if (number == rightNumber)
        {
            StartCoroutine(appearAnwser());
        }
        else
        {
            ShowInCorrectSE();
        }
    }
    public void SelectNumber_1()
    {
        int number = 1;
        if (number == rightNumber)
        {
            StartCoroutine(appearAnwser());
        }
        else
        {
            ShowInCorrectSE();
        }
    }
    public void SelectNumber_2()
    {
        int number = 2;
        if (number == rightNumber)
        {
            StartCoroutine(appearAnwser());
        }
        else
        {
            ShowInCorrectSE();
        }
    }
    public void SelectNumber_3()
    {
        int number = 3;
        if (number == rightNumber)
        {
            StartCoroutine(appearAnwser());
        }
        else
        {
            ShowInCorrectSE();
        }
    }
    public void SelectNumber_4()
    {
        int number = 4;
        if (number == rightNumber)
        {
            StartCoroutine(appearAnwser());
        }
        else
        {
            ShowInCorrectSE();
        }
    }
    public void SelectNumber_5()
    {
        int number = 5;
        if (number == rightNumber)
        {
            StartCoroutine(appearAnwser());
        }
        else
        {
            ShowInCorrectSE();
        }
    }
    public void SelectNumber_6()
    {
        int number = 6;
        if (number == rightNumber)
        {
            StartCoroutine(appearAnwser());
        }
        else
        {
            ShowInCorrectSE();
        }
    }
    public void SelectNumber_7()
    {
        int number = 7;
        if (number == rightNumber)
        {
            StartCoroutine(appearAnwser());
        }
        else
        {
            ShowInCorrectSE();
        }
    }
    public void SelectNumber_8()
    {
        int number = 8;
        if (number == rightNumber)
        {
            StartCoroutine(appearAnwser());
        }
        else
        {
            ShowInCorrectSE();
        }
    }
    public void SelectNumber_9()
    {
        int number = 9;
        if (number == rightNumber)
        {
            StartCoroutine(appearAnwser());
        }
        else
        {
            ShowInCorrectSE();
        }
    }
    public void SelectNumber_10()
    {
        int number = 10;
        if (number == rightNumber)
        {
            StartCoroutine(appearAnwser());
        }
        else
        {
            ShowInCorrectSE();
        }
    }
    public void RetryButton()
    {
        Reset();
        finishPanel.SetActive(false);
    }

    public void ToTitleButton()
    {
        SceneManager.LoadScene("Select");
        MushikuiMoney.instance.Save();
    }

    public void BackButton()
    {
        backPanel.SetActive(true);
    }
    public void YesButton()
    {
        SceneManager.LoadScene("Select");
    }
    public void NoButton()
    {
        backPanel.SetActive(false);
    }

    

    
}
