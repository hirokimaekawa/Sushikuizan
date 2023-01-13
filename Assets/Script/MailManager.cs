using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniMail;


public class MailManager : MonoBehaviour
{

    public void SendMail()
    {
        Debug.Log("押された");
        Mail.Send("hiroki20120903@yahoo.co.jp", "【件名】", "【本文】");
    }
}
