using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SoundButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed;
    [SerializeField] private Animator _music;

    public Boolean toggled = true;
    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (toggled == true)
        {
            toggled = false;
            _img.sprite = _pressed;
            _music.ResetTrigger("FadeIn");
            _music.SetTrigger("FadeOut");
        }
        else
        {
            toggled = true;
            _img.sprite = _default;
            _music.ResetTrigger("FadeOut");
            _music.SetTrigger("FadeIn");
        }
    }
}
