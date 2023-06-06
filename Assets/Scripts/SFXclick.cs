using UnityEngine;
using UnityEngine.EventSystems;

public class SFXclick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AudioSource _SFX;
    [SerializeField] private Animator _button;

    public void OnPointerDown(PointerEventData eventData)
    {
        _button.SetTrigger("Pressed");
        _button.ResetTrigger("Hold");
        _button.SetBool("pressing", true);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _SFX.Play();
        _button.ResetTrigger("Pressed");
        _button.SetTrigger("Hold");
        _button.SetBool("pressing", false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_button.GetBool("pressing") == false)
        {
            _button.SetTrigger("Highlighted");
            _button.ResetTrigger("CanPass");
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_button.GetBool("pressing") == false)
        {
            _button.ResetTrigger("Highlighted");
            _button.SetTrigger("CanPass");
        }
    }
}
