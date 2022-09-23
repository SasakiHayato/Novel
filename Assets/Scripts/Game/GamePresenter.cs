using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    CurrentActorModel _currentActorModel;

    public void OnNext(SheetJsonData.JsonData data)
    {
        UpdateActorData(data);
        SetEventInfo(data);
        UpdateUI(data);
    }

    void UpdateActorData(SheetJsonData.JsonData data)
    {
        string[] actorViewNameArray = data.Actor_ViewName.Split('\n');
        string[] actorFaceTypeArray = data.Actor_FaceType.Split('\n');
        string[] positionTypeArray = data.PsitionType.Split('\n');

        foreach (string actor in actorViewNameArray)
        {
            _currentActorModel.SetActor(actor);
        }

        foreach (string actor in actorFaceTypeArray)
        {
            _currentActorModel.UpdateFaceData(actor);
        }

        foreach (string actor in positionTypeArray)
        {
            _currentActorModel.UpdatePosition(actor);
        }

        _currentActorModel.Save();
    }

    void SetEventInfo(SheetJsonData.JsonData data)
    {
        string[] eventArray = data.EventInfo.Split('\n');

        
    }

    void UpdateUI(SheetJsonData.JsonData data)
    {
        UIManager ui = GameManager.Instance.GetManager<UIManager>(nameof(UIManager));
        ui.UpdateView("Game", "MSG", new object[] { data.Text });
        ui.UpdateView("Game", "Name", new object[] { data.Talker });
    }

    public void Initalize()
    {
        _currentActorModel = new CurrentActorModel();
    }
}
