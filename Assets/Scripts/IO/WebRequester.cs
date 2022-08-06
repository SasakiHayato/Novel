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
    const string GASKey = "AKfycbw9WtV_pn1L-pbYLZ-VrsQLSW1wvGXSDgPq3doF8AfdF5HBtG04tUWWVLKOon1_TF_p";
    public WebRequester(string sheetName, Action<SheetModel> action)
    {
        string path = CreatePath(sheetName);

        _action = action;
        _request = UnityWebRequest.Get(path);
    }

    string CreatePath(string sheetName)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(HTTP + GASKey);
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
