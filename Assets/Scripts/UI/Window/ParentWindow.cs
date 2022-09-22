using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ParentWindow : MonoBehaviour
{
    [SerializeField] string _path;

    List<ChildWindow> _childWindowList;

    public string Path => _path;

    public void Initalize()
    {
        _childWindowList = new List<ChildWindow>();

        int childCount = transform.childCount;

        for (int index = 0; index < childCount; index++)
        {
            ChildWindow window = transform.GetChild(index).GetComponent<ChildWindow>();

            if (window != null)
            {
                _childWindowList.Add(window);
            }
        }
    }

    public void Active(bool isActive)
    {
        gameObject.SetActive(isActive);
        _childWindowList.ForEach(c => c.Active(isActive));
    }

    public void CallBack(string path, object[] data)
    {
        try
        {
            ChildWindow window = _childWindowList.First(c => c.Path == path);
            window.CallBack(data);
        }
        catch
        {
            Debug.Log($"指定したChildWindowパスがありません。{path} is not found");
        }
    }
}
