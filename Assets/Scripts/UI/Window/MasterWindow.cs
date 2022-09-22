using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class MasterWindow : MonoBehaviour
{
    List<ParentWindow> _parentWindowList;

    public List<ParentWindow> ParentWindowList => _parentWindowList;

    public void Setup()
    {
        _parentWindowList = new List<ParentWindow>();

        int childCount = transform.childCount;

        for (int index = 0; index < childCount; index++)
        {
            ParentWindow window = transform.GetChild(index).GetComponent<ParentWindow>();

            if (window != null)
            {
                window.Setup();
                _parentWindowList.Add(window);
            }
        }
    }

    public void WindowActive(string path, bool isAcive)
    {
        try
        {
            ParentWindow window = _parentWindowList.First(p => p.Path == path);
            window.Active(isAcive);
        }
        catch
        {
            Debug.Log($"指定したParentWindowパスがありません。{path} is not found");
        }
    }
}
