using UnityEngine;
using UnityEngine.UI;


public class FadeModel : UIModel
{
    Image _img;

    protected override void Setup()
    {
        _img = GetComponent<Image>();

        Color color = _img.color;
        color = new Color(color.r, color.g, color.b, 0);
        _img.color = color;
    }

    public override void CallBack()
    {
        
    }
}
