using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOptionManager : MonoBehaviour
{

   
    public const int OFF_BGM = 0;
    public const int ON_BGM = 1;
   
    public const int OFF_SE = 0;
    public const int ON_SE = 1;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("BGM_KEY", OFF_BGM) == ON_BGM)
        {
            SoundManager.instance.OnBGM();
        }
        else
        {
            SoundManager.instance.OffBGM();
        }

        if (PlayerPrefs.GetInt("SE_KEY", OFF_SE) == ON_SE)
        {
            SoundManager.instance.OnSE();
        }
        else
        {
            SoundManager.instance.OffSE();
        }
    }

}
