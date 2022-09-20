using UnityEngine;

/// <summary>
/// ゲーム全体の管理クラス
/// </summary>
public class GameViewer : MonoBehaviour
{
    [SerializeField] string _gebugSheetName;
    [SerializeField] GamePresenter _gamePresenter;

    ChapterOperator _chapterOperator;
    SheetJsonData _sheetData;

    void Start()
    {
        _chapterOperator = new ChapterOperator();

        if (_gebugSheetName != null)
        {
            Request(_gebugSheetName);
        }
    }

    void OnNext()
    {
        int currentID = _chapterOperator.CurrentID;
        SheetJsonData.JsonData data = _sheetData.Data[currentID];
        _gamePresenter.OnNext(data);
    }

    void Request(string sheetName)
    {
        _chapterOperator.Initalize();
        WebRequester requester = new WebRequester(sheetName, Get);
    }

    void Get(SheetJsonData data)
    {
        _sheetData = data;
    }
}
