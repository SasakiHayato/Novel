using UnityEngine;
using TMPro;

public class ViewName : ChildWindow
{
    [SerializeField] TextMeshProUGUI _txt;

    protected override void Setup()
    {
        _txt.text = "";
    }

    public override void CallBack(object[] data)
    {
        _txt.text = (string)data[0];
    }
}
