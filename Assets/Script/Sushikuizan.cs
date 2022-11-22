using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    public GameObject correctAnwser;
    public GameObject inCorrectAnwser;
    public GameObject finishPanel;
    public GameObject backPanel;

    public TextMeshProUGUI countText;
    public AdMobInterstitial adMobInterstitial;
    int interstialCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        CreateQuestion();
        countText.text = questionCount+1 + "/10問目";

    }

    // Update is called once per frame
    void Update()
    {
        Finish();
    }

    //このquestionCountは、問題数も兼ねている。
    int questionCount;
    bool isCalledOnce = false;

    void Finish()
    {
        if (questionCount == 10 && isCalledOnce == false)
        {
            finishPanel.SetActive(true);
            Money.instance.getMoney += 10;
            Money.instance.currentMoney += 10;
            Money.instance.sushikuiPlayCount += 1;
            SoundManager.instance.SuccessSE();
            isCalledOnce = true;
            interstialCount++;
        }
    }

        void CreateQuestion()
    {
        if (questionCount < 10)
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

        countText.text = questionCount + 1 + "/10問目";
        }

    }

    void SetLeftSushi(int sushi)
    {
        //ここでは、引数分の寿司を表示する
    }

    public void AnwserButton()
    {
        if (dragSushiTana.count == rightNumber)
        {
            StartCoroutine(CorrectAction());
        }
        else
        {
            StartCoroutine(InCorrectAction());
        }
    }

    IEnumerator CorrectAction()
    {
        questionCount++;

        SoundManager.instance.CorrectSE();
        correctAnwser.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        correctAnwser.SetActive(false);
        CreateQuestion();
        ResetDragSushi();
    }

    IEnumerator InCorrectAction()
    {
        inCorrectAnwser.SetActive(true);
        SoundManager.instance.InCorrectSE();
        yield return new WaitForSeconds(1.0f);
        inCorrectAnwser.SetActive(false);
        ResetDragSushi();
        rightSushiTana.SetSushiImages(0);

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
        ResetDragSushi();
        rightSushiTana.SetSushiImages(0);
        SoundManager.instance.RetrySE();

    }

    void Reset()
    {
        questionCount = 0;
        countText.text = questionCount + 1 + "/10問目";
        isCalledOnce = false; //一回だけ呼び出すために bool配置
        CreateQuestion();
    }

    public void RetryButton()
    {
        TransitionButton();
        Reset();
        finishPanel.SetActive(false);
    }

    public void BackButton()
    {
        TransitionButton();
        backPanel.SetActive(true);
    }
    public void YesButton()
    {
        TransitionButton();
        if (interstialCount >= 1)
        {
            adMobInterstitial.ShowAdMobInterstitial();
        }
        else
        {
            SceneManager.LoadScene("Select");
        }
    }
    public void NoButton()
    {
        TransitionButton();
        backPanel.SetActive(false);
    }
    void TransitionButton()
    {
        SoundManager.instance.TransitionSE();
    }
}
