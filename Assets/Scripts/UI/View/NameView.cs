using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameView : UIView
{
    TextMeshProUGUI _gui;

    protected override void Setup()
    {
        _gui = GetComponentInChildren<TextMeshProUGUI>();
        _gui.text = "";
    }

    public override void CallBack()
    {
        throw new System.NotImplementedException();
    }
}
