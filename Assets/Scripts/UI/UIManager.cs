using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : ManagerBase
{
    [SerializeField] Canvas _canvas;

    Dictionary<string, UIView> _viewDic = new Dictionary<string, UIView>();
   
    protected override void Setup()
    {
        SetView();
    }

    void SetView()
    {
        foreach (UIView view in _canvas.GetComponentsInChildren<UIView>())
        {
            _viewDic.Add(view.Path, view);
        } 
    }

    public void CallBackView(string path)
    {
        UIView view = _viewDic.FirstOrDefault(v => v.Key == path).Value;
        view?.CallBack();
    }

    protected override void Dispose()
    {
        
    }

    protected override string Name() => nameof(UIManager);
}
