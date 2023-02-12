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
        Debug.Log(rect);
        if (PlayerPrefs.HasKey("SUSHI_IMAGE_ID"))
        {
            int sushiImageID = PlayerPrefs.GetInt("SUSHI_IMAGE_ID",0);
            Debug.Log(sushiImageID);
            Debug.Log((SushiID)sushiImageID);
            GetComponent<Image>().sprite = SushiDataBaseSO.Entity.GetSushiData((SushiID)sushiImageID).sushiSprite;
        }
    }

    Rect rect;

    public void OnDrag(PointerEventData eventData)
    {
        float width = 1334f;
        float height = 750f;
        float pixelPerUnit = 100f;

        float screen_w = (float)Screen.width;
        float screen_h = (float)Screen.height;
        float target_w = (float)width;
        float target_h = (float)height;

        //アスペクト比
        float aspect = screen_w / screen_h;
        float targetAcpect = target_w / target_h;
        float orthographicSize = (target_h / 2f / pixelPerUnit);

        //縦に長い
        if (aspect < targetAcpect)
        {
            float bgScale_w = target_w / screen_w;
            float camHeight = target_h / (screen_h * bgScale_w);
            rect = new Rect(0f, (1f - camHeight) * 0.5f, 1f, camHeight);
        }
        // 横に長い
        else
        {
            // カメラのorthographicSizeを横の長さに合わせて設定しなおす
            float bgScale = aspect / targetAcpect;
            //orthographicSize *= bgScale;

            float bgScale_h = target_h / screen_h;
            float camWidth = target_w / (screen_w * bgScale_h);
            rect = new Rect((1f - camWidth) * 0.5f, 0f, camWidth, 1f);
        }

        //Debug.Log(rect);
        //Debug.Log(eventData.position);
        transform.position = eventData.position;

        //寿司の可動範囲を限定するコード
        //transform.position = new Vector3(Mathf.Clamp(eventData.position.x, rect.x*Screen.width*1.4f, rect.width*Screen.width*0.9f),
        //    Mathf.Clamp(eventData.position.y, rect.y*Screen.height*1.5f,rect.height*Screen.height),transform.position.z);
    }

    public Vector3 backPosition;
    public Vector3 pos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        backPosition = this.transform.localPosition;
        Debug.Log(backPosition);
        //defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        backPosition = pos;
        //transform.SetParent(defaultParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.localPosition = Vector3.zero;

    }
}
