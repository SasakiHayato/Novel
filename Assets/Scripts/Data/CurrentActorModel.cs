using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentActorModel
{
    List<CurrentActorData> _currentActorDataList = new List<CurrentActorData>();

    public void FindActor(string path)
    {
        if (_currentActorDataList.Count <= 0)
        {
            CreateActor(path);
        }
    }

    void CreateActor(string path)
    {
        CurrentActorData data = new CurrentActorData();

        string[] name = path.Split("_");
        data.SetPath(name[0]);
        data.SetName(name[1]);
    }
}
