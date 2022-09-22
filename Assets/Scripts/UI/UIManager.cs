using System.Collections;
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
        List<ParentWindow> _parentWindowList = _masterWindow.ParentWindowList;

        try
        {
            ParentWindow window = _parentWindowList.First(p => p.Path == parentPath);
            window.CallBack(childPath, data);
        }
        catch
        {
            Debug.Log($"指定したParentWindowパスがありません。{parentPath} is not found");
        }
    }

    public void PanelActive(string path, bool isActive)
    {
        _masterWindow.WindowActive(path, isActive);
    }
}
