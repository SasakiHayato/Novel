using System;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequester
{
    Action<SheetModel> _action;
    UnityWebRequest _request;

    const string HTTP = "https://script.google.com/macros/s/";
    const string DeployKey = "AKfycbyZvRCKKblQxduyRd-DJeZfEG38ZLb8G00Z-O7iXEIW3t2TV8jbbzdCDgmDQuHLICMf";

    public WebRequester(string sheetName, Action<SheetModel> action)
    {
        string path = CreatePath(sheetName);

        _action = action;
        _request = UnityWebRequest.Get(path);
    }

    string CreatePath(string sheetName)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(HTTP + DeployKey);
        builder.Append("/exec?sheet=");
        builder.Append(sheetName);

        return builder.ToString();
    }

    public void Request<Mono>(Mono mono) where Mono : MonoBehaviour
    {
        mono.StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        yield return _request.SendWebRequest();
        SheetModel data = JsonUtility.FromJson<SheetModel>(_request.downloadHandler.text);
        _action.Invoke(data);
    }
}
