public enum PositionType
{
    CENTER,
    RIGHT,
    LEFT,
}

[System.Serializable]
public class SheetModel 
{
    public string Version;
    public Model[] Data;

    [System.Serializable]
    public class Model
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