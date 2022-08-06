using System.Collections;
using TMPro;

public class TextModel : UIModel
{
    TextMeshProUGUI _gui;

    protected override void Setup()
    {
        _gui = GetComponentInChildren<TextMeshProUGUI>();
    }

    public override void CallBack()
    {
        int length = _gui.text.Length;

        StartCoroutine(LoadText(length));
    }

    IEnumerator LoadText(int length)
    {
        for (int index = 0; index < length; index++)
        {
            _gui.maxVisibleCharacters = index;

            yield return null;
        }
    }
}
