using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : ManagerBase
{
    protected override string Path() => nameof(UIManager);

    protected override ManagerBase Setup()
    {
        return this;
    }

    public void CallBack()
    {

    }
}
