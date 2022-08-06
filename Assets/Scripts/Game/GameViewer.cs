using System;
using UnityEngine;

public class GameViewer : MonoBehaviour
{
    SheetModel.Model _sheetData;
    SheetDataAnalysis _dataAnalysis = new SheetDataAnalysis();

    int _sheetID;

    public Action CallBack { get; private set; }

    void Awake()
    {
        GameManager.Instance.Setup();
        RequestSheet();

        CallBack += SetData;
        CallBack += ViewData; 
    }

    void OnDestroy()
    {
        GameManager.Instance.Dispose();
    }

    void SetData()
    {
        UIManager ui = GameManager.Instance.GetManager<UIManager>(nameof(UIManager));

        SetName(ui);
        SetText(ui);
    }

    void ViewData()
    {
        UIManager ui = GameManager.Instance.GetManager<UIManager>(nameof(UIManager));

        ui.CallBackModel("Text");
    }

    void SetName(UIManager ui)
    {
        string name = _dataAnalysis.Name(_sheetData);
        ui.CallBackView("Name", new object[] { name });
    }

    void SetText(UIManager ui)
    {
        string text = _dataAnalysis.Text(_sheetData);
        ui.CallBackView("Text", new object[] { text });
    }

    void RequestSheet()
    {
        WebRequester requester = new WebRequester("TestSheet", GetSheet);
        requester.Request(this);
    }

    void GetSheet(SheetModel data)
    {
        _sheetID = 0;
        _sheetData = data.Data[_sheetID];
    }
}
