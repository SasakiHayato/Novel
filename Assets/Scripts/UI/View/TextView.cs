using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextView : UIView
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
