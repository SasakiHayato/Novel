/// <summary>
/// ���݃`���v�^�[�̊Ǘ�
/// </summary>
public class ChapterOperator
{
    int _chapterID;
    public int CurrentID { get; private set; }

    public void SetNextID()
    {
        CurrentID++;
    }

    public void Initalize()
    {
        _chapterID = 0;
        CurrentID = 0;
    }
}
