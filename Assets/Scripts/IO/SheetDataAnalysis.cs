using System.Collections.Generic;

public class SheetDataAnalysis
{
    public string ViewName(SheetModel.Model data)
    {
        string[] nameArray = data.Talker_ViewName.Split('_');

        if (nameArray[1] == "")
        {
            nameArray[1] = nameArray[0];
        }

        return nameArray[1];
    }

    public string Talker(SheetModel.Model data)
    {
        string[] nameArray = data.Talker_ViewName.Split('_');
        return nameArray[0];
    }

    public FaceType Face(SheetModel.Model data)
    {
        if (data.FaceType == FaceType.Default.ToString())
        {
            return FaceType.Default;
        }
        else
        {
            return FaceType.Silhouette;
        }
    }

    public string Text(SheetModel.Model data)
    {
        return data.Text.Replace("[N]", GameManager.Instance.UserName);
    }

    public PositionType Position(SheetModel.Model data)
    {
        if (data.PsitionType == PositionType.CENTER.ToString())
        {
            return PositionType.CENTER;
        }
        else if (data.PsitionType == PositionType.RIGHT.ToString())
        {
            return PositionType.RIGHT;
        }
        else
        {
            return PositionType.LEFT;
        }
    }

    public bool HasEvent(SheetModel.Model data)
    {
        string has = data.HasEvent;

        if (has == "TRUE")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<EventInfoData> EventInfo(SheetModel.Model data)
    {
        List<EventInfoData> eventList = new List<EventInfoData>();

        string[] eventInfoArray = data.EventInfo.Split('\n');

        foreach (string info in eventInfoArray)
        {
            string[] infoData = info.Split('_');

            eventList.Add(SetEvent(infoData));
        }

        return eventList;
    }

    EventInfoData SetEvent(string[] info)
    {
        if (info[0] == EventType.Fade.ToString())
        {
            FadeEventData fadeEvent = new FadeEventData();
            fadeEvent.EventType = EventType.Fade;
            fadeEvent.SetTarget(info[1]);
            fadeEvent.SetType(info[2]);

            return fadeEvent;
        }
        else
        {
            UserInputEventData inputEventData = new UserInputEventData();
            inputEventData.EventType = EventType.UserInput;
            inputEventData.SetEventType(info[1]);

            return inputEventData;
        }
    }
}
