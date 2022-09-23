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

        _gamePresenter.Initalize();

        if (_gebugSheetName != "")
        {
            Request(_gebugSheetName);
        }

        _userInputter.SetAction(() => OnNext());
    }

    void OnNext()
    {
        int currentID = _chapterOperator.CurrentID;

        SheetJsonData.JsonData data = _sheetData.Data[currentID];
        _gamePresenter.OnNext(data);

        _chapterOperator.SetNextID();

        try
        {
            
        }
        catch
        {
            Debug.Log("チャプターが終了しました。");
            _chapterOperator.Initalize();
        }
    }

    void Request(string sheetName)
    {
        WebRequester requester = new WebRequester(sheetName, Get);
        requester.Request(this);
    }

    void Get(SheetJsonData data)
    {
        _sheetData = data;
    }
}
