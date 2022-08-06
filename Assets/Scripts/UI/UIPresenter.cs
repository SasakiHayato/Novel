using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPresenter : MonoBehaviour
{
    [SerializeField] string _path;

    public string Path => _path;

    public abstract void Process();
}
