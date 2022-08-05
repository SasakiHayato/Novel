using System.Collections.Generic;
using System.Linq;

public class GameManager
{
    // Singleton
    private static GameManager s_instance = new GameManager();
    public static GameManager Instance => s_instance;

    Dictionary<string, ManagerBase> _managerDic;

    public void Setup()
    {
        _managerDic = new Dictionary<string, ManagerBase>();
    }

    public void Dispose()
    {

    }

    public void AddManager<Manager>(Manager manager, string name) where Manager: ManagerBase
    {
        _managerDic.Add(name, manager);
    }

    public Manager GetManager<Manager>(string key) where Manager : ManagerBase
    {
        return (Manager)_managerDic.FirstOrDefault(m => m.Key == key).Value;
    }
}
