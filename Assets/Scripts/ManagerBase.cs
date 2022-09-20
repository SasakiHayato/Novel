using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManagerBase : MonoBehaviour
{
    void Awake()
    {
        ManagerBase manager = Setup();
        GameManager.Instance.AddManager(manager, manager.Path());
    }

    protected abstract ManagerBase Setup();

    protected abstract string Path();
}
