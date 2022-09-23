public enum PositionType
{
    CENTER,
    RIGHT,
    LEFT,

    NONE,
}

/// <summary>
/// スプレッドシートのデータ
/// </summary>
[System.Serializable]
public class SheetJsonData 
{
    public string Version;
    public JsonData[] Data;

    [System.Serializable]
    public class JsonData
    {
        public string Actor_ViewName;
        public string Text;
        public string Actor_FaceType;
        public string PositionType;
        public string Talker;
        public string BackView;
        public string EventInfo;
    }
}