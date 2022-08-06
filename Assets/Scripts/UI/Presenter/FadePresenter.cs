using UnityEngine;

public interface IFadePresentable
{
    FadeEventData GetEventData();
}

public class FadePresenter : UIPresenter
{
    [SerializeField] FadeModel _model;

    public override void Process()
    {
        
    }
}
