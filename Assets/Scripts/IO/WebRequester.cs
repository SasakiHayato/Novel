using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequester
{
    Action<SheetData> _action;
    UnityWebRequest _request;

    const string HTTP = "https://script.google.com/macros/s/AKfycbw9WtV_pn1L-pbYLZ-VrsQLSW1wvGXSDgPq3doF8AfdF5HBtG04tUWWVLKOon1_TF_p/exec?sheet=";
    public WebRequester(string sheetName, Action<SheetData> action)
    {
        string path = HTTP + sheetName;
        _action = action;
        _request = UnityWebRequest.Get(path);

    }

    public void Request<Mono>(Mono mono) where Mono : MonoBehaviour
    {
        mono.StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        yield return _request.SendWebRequest();
        SheetData data = JsonUtility.FromJson<SheetData>(_request.downloadHandler.text);
        _action.Invoke(data);
    }
}
