using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    CurrentActorModel _currentActorModel;

    public void OnNext(SheetJsonData.JsonData data)
    {
        UpdateActorData(data);
        UpdateUI(data);
    }

    void UpdateActorData(SheetJsonData.JsonData data)
    {
        string[] viewNameArray = data.Actor_ViewName.Split('\n');

        foreach (string name in viewNameArray)
        {
            _currentActorModel.FindActor(name);
        }
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
