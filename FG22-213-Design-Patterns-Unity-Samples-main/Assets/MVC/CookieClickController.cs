using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CookieClickController : MonoBehaviour, IPointerClickHandler
{
    public int cookiesToAdd = 1;
    [SerializeField] private CookiesModel _cookiesModel;

    public void OnPointerClick(PointerEventData eventData)
    {
        _cookiesModel.Cookies+=cookiesToAdd;
    }
}
