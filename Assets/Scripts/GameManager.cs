using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager
{
    public static GameManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = new GameManager();
            }

            return s_instance;
        }
    }
    private static GameManager s_instance;

    Dictionary<string, ManagerBase> _managerDic = new Dictionary<string, ManagerBase>();

    public string UserName { get; private set; }

    public void SetUserName(string name) => UserName = name;

    public void AddManager<Manager>(Manager manager, string path) where Manager : ManagerBase
    {
        _managerDic.Add(path, manager);
    }

    public Manager GetManager<Manager>(string path) where Manager : ManagerBase
    {
        ManagerBase manager = _managerDic.FirstOrDefault(m => m.Key == path).Value;
        return manager as Manager;
    }
}
