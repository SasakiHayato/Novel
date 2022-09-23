using UnityEngine;
using TMPro;

public class ViewText : ChildWindow
{
    [SerializeField] TextMeshProUGUI _txt;

    protected override void Setup()
    {
        _txt.text = "";
    }

    public override void CallBack(object[] data)
    {
        _txt.text = SetEvent((string)data[0]);
    }

    string SetEvent(string text)
    {
        text = text.Replace("[N]", GameManager.Instance.UserName);

        return text;
    }
}
