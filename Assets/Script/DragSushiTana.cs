using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragSushiTana : MonoBehaviour,IDropHandler
{

    [SerializeField] bool canMove;
    public int count;
    public Image[] sushiTanaImages;
    AudioSource audioSource;
    public AudioClip popSushiSE;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void SetSushiImages(int count)
    {
        this.count = count;
        for (int i = 0; i < sushiTanaImages.Length; i++)
        {
            if (i < count)
            {
                sushiTanaImages[i].gameObject.SetActive(true);
            }
            else
            {
                sushiTanaImages[i].gameObject.SetActive(false);
            }
        }

    }

    public void AddSushi()
    {
        count++;
        SetSushiImages(count);
        //audioSource.PlayOneShot(popSushiSE);
        SoundManager.instance.PopSushiSE();
    }

    public void RemoveSushi()
    {
        count--;
        SetSushiImages(count);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (!canMove)
        {
            return;
        }
        DragSushi dragSushi = eventData.pointerDrag.GetComponent<DragSushi>();
        if (dragSushi)
        {
            //Destroy(dragSushi.gameObject);
            dragSushi.transform.SetParent(dragSushi.defaultParent, false);
            dragSushi.transform.localPosition = Vector3.zero;
            dragSushi.gameObject.SetActive(false); // 寿司は消えるが、元の場所に戻らない
            AddSushi();
        }
    }
}
