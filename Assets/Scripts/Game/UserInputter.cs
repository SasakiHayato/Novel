using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class UserInputter : MonoBehaviour
{
    ReactiveProperty<bool> _reactiveBool = new ReactiveProperty<bool>();

    Action _action;

    void Start()
    {
        _reactiveBool
            .ObserveEveryValueChanged(o => o.Value = Input.GetButtonDown("Fire1"))
            .Select(s => s)
            .ThrottleFirst(TimeSpan.FromSeconds(0.5f))
            .Subscribe(_ => _action?.Invoke())
            .AddTo(this);

        _reactiveBool.SkipLatestValueOnSubscribe();
    }

    public void SetAction(Action action) => _action = action;
}
