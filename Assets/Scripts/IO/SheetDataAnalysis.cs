public class SheetDataAnalysis
{
    public string[] Name(SheetModel.Model data)
    {
        return data.Talker.Split('_');
    }

    public string Text(SheetModel.Model data)
    {
        return data.Text.Replace("[N]", GameManager.Instance.UserName);
    }
}
