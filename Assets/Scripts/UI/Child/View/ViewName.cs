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
        CurrentActorData actorData = GameManager.Instance.GetCurrrentActorData((string)data[0]);

        _txt.text = actorData.ViewName;
    }
}
