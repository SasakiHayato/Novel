public class SheetDataAnalysis
{
    public string Name(SheetModel.Model data)
    {
        string[] nameArray = data.Talker_ViewName.Split('_');

        string name;

        if (nameArray[1] == "")
        {
            name = nameArray[0];
        }
        else
        {
            name = nameArray[1];
        }

        return name;
    }

    public string Text(SheetModel.Model data)
    {
        return data.Text.Replace("[N]", GameManager.Instance.UserName);
    }
}
