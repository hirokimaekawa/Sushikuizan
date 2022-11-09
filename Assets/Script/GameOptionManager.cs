using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOptionManager : MonoBehaviour
{

    public GameObject soundPanel;
    public GameObject contactPanel;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundButton()
    {
        soundPanel.SetActive(true);
        TransitionButton();
    }

    public void BackSoundButton()
    {
        soundPanel.SetActive(false);
        TransitionButton();
    }
    public void HowPlayButton()
    {

    }

    public void ContactButton()
    {
        contactPanel.SetActive(true);
        TransitionButton();
    }
    public void BackContactButton()
    {
        contactPanel.SetActive(false);
        TransitionButton();
    }

    public void BackButton()
    {
        TransitionButton();
        SceneManager.LoadScene("Select");
    }

    public void OnBGMButton()
    {
        SoundManager.instance.OnBGM();
    }
    public void OffBGMButton()
    {
        SoundManager.instance.OffBGM();
    }
    public void OnSEButton()
    {
        SoundManager.instance.OnSE();
        TransitionButton();
    }
    public void OffSEButton()
    {
        SoundManager.instance.OffSE();
    }
    void TransitionButton()
    {
        SoundManager.instance.TransitionSE();
    }
}
