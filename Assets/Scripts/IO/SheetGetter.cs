using UnityEngine;

public class SheetGetter : MonoBehaviour
{
    void Start()
    {
        WebRequester requester = new WebRequester("TestSheet", Get);
        requester.Request(this);
    }

    void Get(SheetData data)
    {
        Debug.Log(data);
    }
}
