using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : ManagerBase
{
    [SerializeField] Canvas _canvas;

    Dictionary<string, UIView> _viewDic = new Dictionary<string, UIView>();
    Dictionary<string, UIModel> _modelDic = new Dictionary<string, UIModel>();
   
    protected override void Setup()
    {
        AddUI();
    }

    void AddUI()
    {
        foreach (UIView view in _canvas.GetComponentsInChildren<UIView>())
        {
            _viewDic.Add(view.Path, view);
        }

        foreach (UIModel model in _canvas.GetComponentsInChildren<UIModel>())
        {
            _modelDic.Add(model.Path, model);
        }
    }

    public void CallBackView(string path, object[] datas)
    {
        UIView view = _viewDic.FirstOrDefault(v => v.Key == path).Value;
        view?.CallBack(datas);
    }

    public void CallBackModel(string path)
    {
        UIModel model = _modelDic.FirstOrDefault(m => m.Key == path).Value;
        model.CallBack();
    }

    protected override void Dispose()
    {
        
    }

    protected override string Name() => nameof(UIManager);
}
