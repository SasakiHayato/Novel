[System.Serializable]
public class SheetModel 
{
    public string Version;
    public Model[] Data;

    [System.Serializable]
    public class Model
    {
        public string Talker_ViewName;
        public string FaceType;
        public string Text;
        public string StandType;
        public string PsitionType;
        public string HasEvent;
        public string EventInfo;
        public string CharaMoveEvent;
    }
}