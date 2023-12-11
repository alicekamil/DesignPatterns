using UnityEngine;
using UnityEngine.UI;

public class CookieSliderView : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 100;
        slider.value = 0;
        Broker.AddListener("CookiesChanged", OnCookiesChanged);
    }
    
    public void OnCookiesChanged(object cookies)
    {
        slider.value = (int)cookies;
    }
}