using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragSushiTana : MonoBehaviour,IDropHandler
{

    [SerializeField] bool canMove;
    int count;
    [SerializeField] Image[] images;
    
    
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
            //transform.SetParent(dragSushi.defaultParent.parent, false);
            dragSushi.transform.localPosition = Vector3.zero;
            dragSushi.gameObject.SetActive(false); // 寿司は消えるが、元の場所に戻らない
            AddSushi();
        }
    }
}
