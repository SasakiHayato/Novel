/// <summary>
/// 現在チャプターの管理
/// </summary>
public class ChapterOperator
{
    int _chapterID;
    public int CurrentID { get; private set; }

    public void Initalize()
    {
        _chapterID = 0;
        CurrentID = 0;
    }
}
