using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapCoin : MonoBehaviour
{
    [SerializeField] Image coinImage;
    //public Image stamp;
    //public Sprite sprite;

    public static TapCoin instance;

    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        coinImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchImage(Sprite sprite)
    {
        Debug.Log(sprite);
        coinImage.sprite = sprite;
        Debug.Log(sprite);

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //SwitchImage();
        }
    }
    
}
