using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewActorPresenter : ChildWindow
{
    [SerializeField] ViewActor _view;
    ViewActorModel _model;

    const int ActorCount = 3;

    protected override void Setup()
    {
        _model = new ViewActorModel(ActorCount, transform);
    }

    public override void CallBack(object[] data)
    {
        string key = (string)data[0];
        ActorDataBase dataBase = (ActorDataBase)data[1];

        
    }
}
