using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : ManagerBase
{
    [SerializeField] MasterWindow _masterWindow;
    [SerializeField] BackViewDataBase _backViewDataBase;
    [SerializeField] List<ActorDataBase> _actorDataBaseList;

    protected override string Path() => nameof(UIManager);

    protected override ManagerBase Setup()
    {
        _masterWindow.Setup();
        
        return this;
    }

    public void UpdateView(string parentPath, string childPath, object[] data = null)
    {
        List<ParentWindow> parentWindowList = _masterWindow.ParentWindowList;

        try
        {
            ParentWindow window = parentWindowList.First(p => p.Path == parentPath);
            window.CallBack(childPath, data);
        }
        catch
        {
            Debug.Log($"指定したParentWindowパスがありません。{parentPath} is not found");
        }
    }

    public void UpdateBackView(string path)
    {
        if (path == "")
        {
            Debug.Log("背景データに変更がありませんでした。");
            return;
        }

        Sprite sprite = _backViewDataBase.GetData(path);

        UpdateView("Game", "BackView", new object[] { sprite });
    }

    public void UpdateActorView(string[] keys)
    {
        foreach (string key in keys)
        {
            ActorDataBase data = _actorDataBaseList.First(a => a.Path == key);
            CurrentActorData actorData = GameManager.Instance.GetCurrrentActorData(key);

            UpdateView("Game", "Actor", new object[] { key, data });
        }
    }

    public void PanelActive(string path, bool isActive)
    {
        _masterWindow.WindowActive(path, isActive);
    }
}
