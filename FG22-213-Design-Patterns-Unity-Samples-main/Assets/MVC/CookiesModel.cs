using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CookiesModel : MonoBehaviour
{
    private int _cookies;

    public int Cookies
    {
        get => _cookies;
        set
        {
            _cookies = value;
            Broker.SendMessage("CookiesChanged", value);
        }
    }
}
