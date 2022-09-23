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
            Debug.Log("ActorDataが見つかりませんでした。新しく作成します。");

            CurrentActorData actorData = CreateActor(path);
            _currentActorDataList.Add(actorData);
        }
    }

    public string[] GetCurrentActorsKey()
    {
        List<string> actorKeyList = new List<string>();

        foreach (CurrentActorData item in _currentActorDataList)
        {
            actorKeyList.Add(item.ActorKey);
        }

        return actorKeyList.ToArray();
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

    public void UpdateViewName(string path)
    {
        string[] key = path.Split("_");
        CurrentActorData actorData = FindActor(key[0]);

        try
        {
            actorData.SetViewName(key[1]);
        }
        catch
        {
            Debug.Log($"なまえに変更がありませんでした。対象者 => {key[0]}");
        }        
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
        CurrentActorData actorData = FindActor(key[0]);

        PositionType type = PositionType.NONE;

        if (key[1].Contains("C"))
        {
            type = PositionType.CENTER;
        }
        else if (key[1].Contains("R"))
        {
            type = PositionType.RIGHT;
        }
        else if (key[1].Contains("L"))
        {
            type = PositionType.LEFT;
        }

        actorData.SetPosition(type);
    }

    public void Save()
    {
        GameManager.Instance.SetCurrentActor(_currentActorDataList);
    }
}
