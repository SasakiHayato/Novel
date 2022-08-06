using System;
using System.Collections.Generic;
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
        CallBack += ModelData; 
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
        SetPosition(ui);

        bool hasEvent = _dataAnalysis.HasEvent(_sheetData);

        if (hasEvent)
        {
            SetEventInfo(ui);
        }
    }

    void ModelData()
    {
        UIManager ui = GameManager.Instance.GetManager<UIManager>(nameof(UIManager));

        ui.CallBackModel("Text");
    }

    void SetName(UIManager ui)
    {
        string name = _dataAnalysis.ViewName(_sheetData);
        ui.CallBackView("Name", new object[] { name });
    }

    void SetPosition(UIManager ui)
    {
        string name = _dataAnalysis.Talker(_sheetData);
        FaceType faceType = _dataAnalysis.Face(_sheetData);
        PositionType position = _dataAnalysis.Position(_sheetData);

        StandPresenter stand = ui.CallBackPresenter<StandPresenter>("StandPsition");
        stand.SetTaker(name, faceType);
        stand.SetPosition(position);
    }

    void SetText(UIManager ui)
    {
        string text = _dataAnalysis.Text(_sheetData);
        ui.CallBackView("Text", new object[] { text });
    }

    //aaaaaaaa
    void SetEventInfo(UIManager ui)
    {
        List<EventInfoData> dataList = _dataAnalysis.EventInfo(_sheetData);

        foreach (EventInfoData data in dataList)
        {
            FadeEventData fadeData = data as FadeEventData;
            UserInputEventData inputData = data as UserInputEventData;

            if (fadeData != null)
            {

            }
            else if (inputData != null)
            {

            }
        }
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
