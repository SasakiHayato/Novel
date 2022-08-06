using TMPro;

public class NameView : UIView
{
    TextMeshProUGUI _gui;

    protected override void Setup()
    {
        _gui = GetComponentInChildren<TextMeshProUGUI>();
        _gui.text = "";
    }

    public override void CallBack(object[] datas)
    {
        _gui.text = (string)datas[0];
    }
}
