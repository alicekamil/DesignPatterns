using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Singleton;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CookieView : MonoBehaviour
{
    public TMP_Text cookieLabel;
    
    void Start()
    {
        Broker.AddListener("CookiesChanged", OnCookiesChanged);
    }
    
    public void OnCookiesChanged(object cookies)
    {
        cookieLabel.text = $"{cookies} Cookies";
    }
}
