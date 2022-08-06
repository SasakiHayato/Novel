public enum UserEventType
{
    SetName,
}

public class UserInputEventData : EventInfoData
{
    public UserEventType Type;

    public void SetEventType(string type)
    {
        if (type == UserEventType.SetName.ToString())
        {
            Type = UserEventType.SetName;
        }
    }
}
