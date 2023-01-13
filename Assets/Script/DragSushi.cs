using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragSushi : MonoBehaviour,IDragHandler ,IBeginDragHandler,IEndDragHandler
{
    public Transform defaultParent;


    void Awake()
    {
        if (PlayerPrefs.HasKey("SUSHI_IMAGE_ID"))
        {
            int sushiImageID = PlayerPrefs.GetInt("SUSHI_IMAGE_ID",0);
            Debug.Log(sushiImageID);
            Debug.Log((SushiID)sushiImageID);
            GetComponent<Image>().sprite = SushiDataBaseSO.Entity.GetSushiData((SushiID)sushiImageID).sushiSprite;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.localPosition = Vector3.zero;

    }
}
