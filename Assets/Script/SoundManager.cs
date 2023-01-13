using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            audioSourceBGM = GetComponent<AudioSource>();

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    AudioSource audioSourceBGM;
    public AudioSource audioSourceSE;

    //すしくいざんとむしくいざんのSE
    public AudioClip correctSE;
    public AudioClip inCorrectSE;
    public AudioClip retrySE;
    public AudioClip successSE;
    public AudioClip popSushiSE;
    public AudioClip transitionSE;
    public AudioClip bonusSE;
    public AudioClip buySE;
    public AudioClip notBuySE;
    public AudioClip decideSushiSE;


    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBGM()
    {
        audioSourceBGM.volume = 1.0f;
    }

    public void OffBGM()
    {
        audioSourceBGM.volume = 0.0f;

    }

    public void OnSE()
    {
        audioSourceSE.volume =  1.0f;
    }
    public void OffSE()
    {
        audioSourceSE.volume = 0.0f;
    }

    public void CorrectSE()
    {
        audioSourceSE.PlayOneShot(correctSE);
    }

    public void InCorrectSE()
    {
        audioSourceSE.PlayOneShot(inCorrectSE);
    }
    public void RetrySE()
    {
        audioSourceSE.PlayOneShot(retrySE);
    }
    public void SuccessSE()
    {
        audioSourceSE.PlayOneShot(successSE);
    }
    public void PopSushiSE()
    {
        audioSourceSE.PlayOneShot(popSushiSE);
    }
    public void TransitionSE()
    {
        audioSourceSE.PlayOneShot(transitionSE);
    }
    public void BonusSE()
    {
        audioSourceSE.PlayOneShot(bonusSE);
    }
    public void BuySE()
    {
        audioSourceSE.PlayOneShot(buySE);
    }
    public void NotBuySE()
    {
        audioSourceSE.PlayOneShot(notBuySE);

    }
    public void DecideSushi()
    {
        audioSourceSE.PlayOneShot(decideSushiSE);
    }
}
