public enum FadeTarget
{
    Game,
    Talker,
}

public enum FadeType
{
    In,
    Out,
    Cross,
}

public class FadeEventData : EventInfoData
{
    public FadeTarget Target { get; private set; }
    public FadeType Type { get; private set; }

    public void SetTarget(string target)
    {
        if (target == FadeTarget.Game.ToString())
        {
            Target = FadeTarget.Game;
        }
        else
        {
            Target = FadeTarget.Talker;
        }
    }

    public void SetType(string type)
    {
        if (type == FadeType.In.ToString())
        {
            Type = FadeType.In;
        }
        else if (type == FadeType.Out.ToString())
        {
            Type = FadeType.Out;
        }
        else
        {
            Type = FadeType.Cross;
        }
    }
}