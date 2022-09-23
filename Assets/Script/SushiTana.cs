using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SushiTana : MonoBehaviour
{
   
    int count;
    [SerializeField] Image[] images;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSushiImages(int count)
    {
        this.count = count;
        for (int i = 0; i < images.Length; i++)
        {
            if (i < count)
            {
                images[i].gameObject.SetActive(true);
            }
            else
            {
                images[i].gameObject.SetActive(false);
            }
        }

    }

    public void AddSushi()
    {
        count++;
        SetSushiImages(count);
    }

    public void RemoveSushi()
    {
        count--;
        SetSushiImages(count);
    }
}
