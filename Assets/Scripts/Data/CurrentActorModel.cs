using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class CurrentActorModel
{
    List<CurrentActorData> _currentActorDataList = new List<CurrentActorData>();

    public void SetActor(string path)
    {
        string[] key = path.Split("_");

        if (_currentActorDataList.Count <= 0 || !_currentActorDataList.Any(c => c.ActorKey == key[0]))
        {
            Debug.Log("ActorData‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ‚Å‚µ‚½BV‚µ‚­ì¬‚µ‚Ü‚·B");

            CurrentActorData actorData = CreateActor(path);
            _currentActorDataList.Add(actorData);
        }
    }

    CurrentActorData CreateActor(string path)
    {
        CurrentActorData data = new CurrentActorData();

        string[] kay = path.Split("_");
        data.SetActorKey(kay[0]);
        data.SetViewName(kay[1]);

        return data;
    }

    CurrentActorData FindActor(string key)
    {
        return _currentActorDataList.First(c => c.ActorKey == key);
    }

    public void UpdateFaceData(string path)
    {
        string[] key = path.Split("_");

        FaceType type = (FaceType)Enum.Parse(typeof(FaceType), key[1]);
        CurrentActorData actorData = FindActor(key[0]);

        actorData.SetFaceType(type);
    }

    public void UpdatePosition(string path)
    {
        string[] key = path.Split("_");

        PositionType type = (PositionType)Enum.Parse(typeof(PositionType), key[1]);
        CurrentActorData actorData = FindActor(key[0]);

        actorData.SetPosition(type);
    }

    public void Save()
    {
        GameManager.Instance.SetCurrentActor(_currentActorDataList);
    }
}
