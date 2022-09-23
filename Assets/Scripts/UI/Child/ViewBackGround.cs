using UnityEngine;
using UnityEngine.UI;

public class ViewBackGround : ChildWindow
{
    [SerializeField] Image _source;

    protected override void Setup()
    {
        _source.sprite = null;
    }

    public override void CallBack(object[] data)
    {
        _source.sprite = (Sprite)data[0];
    }
}
