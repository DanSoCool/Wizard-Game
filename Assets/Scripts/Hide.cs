using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hide : MonoBehaviour,IPointerUpHandler
{
    [SerializeField] private GameObject _target;
    [SerializeField] private AudioSource _source;
    [SerializeField] private int _time;
    [SerializeField] private GameObject _previous;
    [SerializeField] private GameObject _next;

    public async void OnPointerUp(PointerEventData eventData)
    {
        _source.Play();
        await Task.Delay(_time);
        _target.SetActive(false);
        _previous.SetActive(false);
        _next.SetActive(true);
    }
}
