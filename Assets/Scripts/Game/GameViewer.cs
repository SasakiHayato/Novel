using UnityEngine;

/// <summary>
/// ゲーム全体の管理クラス
/// </summary>
public class GameViewer : MonoBehaviour
{
    [SerializeField] string _gebugSheetName;
    [SerializeField] UserInputter _userInputter;
    [SerializeField] GamePresenter _gamePresenter;

    ChapterOperator _chapterOperator;
    SheetJsonData _sheetData;

    void Start()
    {
        _chapterOperator = new ChapterOperator();
        _chapterOperator.Initalize();

        if (_gebugSheetName != "")
        {
            Request(_gebugSheetName);
        }

        _userInputter.SetAction(() => OnNext());
    }

    bool a = false;

    void OnNext()
    {
        if (!a)
        {
            a = true;
            return;
        }

        int currentID = _chapterOperator.CurrentID;
        _chapterOperator.SetNextID();

        try
        {
            SheetJsonData.JsonData data = _sheetData.Data[currentID];
            _gamePresenter.OnNext(data);
        }
        catch
        {
            Debug.Log("チャプターが終了しました。");
        }
    }

    void Request(string sheetName)
    {
        _chapterOperator.Initalize();
        WebRequester requester = new WebRequester(sheetName, Get);
        requester.Request(this);
    }

    void Get(SheetJsonData data)
    {
        _sheetData = data;
    }
}
