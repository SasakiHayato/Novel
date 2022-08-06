using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIView : MonoBehaviour
{
    [SerializeField] string _path;

    public string Path => _path;

    void Start()
    {
        Setup();
    }

    protected abstract void Setup();

    public abstract void CallBack(object[] datas);
}
