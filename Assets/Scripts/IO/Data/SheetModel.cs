[System.Serializable]
public class SheetModel 
{
    public Data[] Data;
}

[System.Serializable]
public class Data
{
    public string Talker;
    public string FaceType;
    public string Text;
    public string StandType;
    public string PsitionType;
    public string HasEvent;
    public string EventInfo;
    public string CharaMoveEvent;
}