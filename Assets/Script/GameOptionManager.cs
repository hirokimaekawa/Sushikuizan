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
    }

    public void BackSoundButton()
    {
        soundPanel.SetActive(false);
    }
    public void HowPlayButton()
    {

    }

    public void ContactButton()
    {
        contactPanel.SetActive(true);
    }
    public void BackContactButton()
    {
        contactPanel.SetActive(false);
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Select");
    }
}
