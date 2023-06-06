using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private RawImage _img1;
    [SerializeField] private RawImage _img2;
    [SerializeField] private RawImage _img3;

    [SerializeField] private float _x, _y;

    void Update ()
    {
        _img1.uvRect = new Rect(_img1.uvRect.position + new Vector2(_x, _y) * Time.deltaTime,_img1.uvRect.size);
        _img2.uvRect = new Rect(_img2.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img2.uvRect.size);
        _img3.uvRect = new Rect(_img3.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img3.uvRect.size);
    }
}
