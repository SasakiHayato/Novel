using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : ManagerBase
{
    [SerializeField] Canvas _canvas;
    [SerializeField] List<CharaModelData> _modelList;

    Dictionary<string, UIView> _viewDic = new Dictionary<string, UIView>();
    Dictionary<string, UIModel> _modelDic = new Dictionary<string, UIModel>();
    Dictionary<string, UIPresenter> _presenterDic = new Dictionary<string, UIPresenter>();
   
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

        foreach (UIPresenter presenter in _canvas.GetComponentsInChildren<UIPresenter>())
        {
            _presenterDic.Add(presenter.Path, presenter);
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

    public Presenter CallBackPresenter<Presenter>(string path) where Presenter : UIPresenter
    {
        UIPresenter presenter = _presenterDic.FirstOrDefault(p => p.Key == path).Value;

        return (Presenter)presenter;
    }

    public CharaModelData GetCharaModel(string name)
    {
        CharaModelData data = _modelList.FirstOrDefault(m => m.CharaName == name);
        return data;
    }

    protected override void Dispose()
    {
        
    }

    protected override string Name() => nameof(UIManager);
}
