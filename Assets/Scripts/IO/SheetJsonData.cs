public enum PositionType
{
    CENTER,
    RIGHT,
    LEFT,
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
        public string PsitionType;
        public string Talker;
        public string EventInfo;
        public string CharaMoveEvent;
        public string SoundEvent;
    }
}