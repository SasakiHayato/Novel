using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    public void OnNext(SheetJsonData.JsonData data)
    {
        UpdateUI(data);
    }

    void UpdateUI(SheetJsonData.JsonData data)
    {
        UIManager ui = GameManager.Instance.GetManager<UIManager>(nameof(UIManager));
        ui.UpdateView("Game", "MSG", new object[] { data.Text });
    }
}
