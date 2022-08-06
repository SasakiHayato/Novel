using UnityEngine;
using System;
using UniRx;

public class UserInput : MonoBehaviour
{
    [SerializeField] GameViewer _viewer;

    BoolReactiveProperty _boolReactive = new BoolReactiveProperty();

    void Start()
    {
        _boolReactive
            .AsObservable()
            .TakeUntilDestroy(this)
            .ThrottleFirst(TimeSpan.FromSeconds(0.5f))
            .Subscribe(b => OnClick(b));
    }

    void Update()
    {
        _boolReactive.Value = Input.GetButtonDown("Fire1");
    }

    void OnClick(bool isClick)
    {
        if (isClick)
        {
            _viewer.CallBack.Invoke();
        }
    }
}
