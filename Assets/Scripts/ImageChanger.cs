using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image Selected;

    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public void LoadSprite()
    {
        Selected.sprite = one;
    }

    public void onPrev()
    {
        if (Selected.sprite == one) 
        {
            Selected.sprite = five;
        }
        else if (Selected.sprite == five)
        { 
            Selected.sprite = four;
        }
        else if (Selected.sprite == four)
        {
            Selected.sprite = three;
        }
        else if (Selected.sprite == three)
        {
            Selected.sprite = two;
        }
        else if (Selected.sprite == two)
        {
            Selected.sprite = one;
        }
    }

    public void onNext()
    {
        if (Selected.sprite == one)
        {
            Selected.sprite = two;
        }
        else if (Selected.sprite == two)
        {
            Selected.sprite = three;
        }
        else if (Selected.sprite == three)
        {
            Selected.sprite = four;
        }
        else if (Selected.sprite == four)
        {
            Selected.sprite = five;
        }
        else if (Selected.sprite == five)
        {
            Selected.sprite = one;
        }
    }
}
