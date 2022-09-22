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
        if (text == "[Close]")
        {
            text = text.Replace("[Close]", "");
            Active(false);
        }

        if (text == "[Open]")
        {
            text = text.Replace("[Open]", "");
            Active(true);
        }

        if (text == "[N]")
        {
            text = text.Replace("[N]", GameManager.Instance.UserName);
        }

        return text;
    }
}
