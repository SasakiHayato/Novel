using System;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// スプレッドシートからのデータを受け取る
/// </summary>
public class WebRequester
{
    Action<SheetJsonData> _action;
    UnityWebRequest _request;

    const string HTTP = "https://script.google.com/macros/s/";
    const string DeployID = "AKfycbyvo916dNYdhRmipoaD6vvBpkOQ9OUEpZpNI4FHm8aLXNtnmsA9kpT9dALOXYcFSZiz";

    /// <summary>
    /// リクエスト作成
    /// </summary>
    /// <param name="sheetName">受け取るシートの名前</param>
    /// <param name="action">受け取った際のAction</param>
    public WebRequester(string sheetName, Action<SheetJsonData> action)
    {
        string path = CreatePath(sheetName);

        _action = action;
        _request = UnityWebRequest.Get(path);
    }

    // 受け取るシートパスの作成
    string CreatePath(string sheetName)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(HTTP + DeployID);
        builder.Append("/exec?sheet=");
        builder.Append(sheetName);

        return builder.ToString();
    }

    /// <summary>
    /// Web上へ申請を行う
    /// </summary>
    /// <typeparam name="Mono">MonoBehaviour</typeparam>
    /// <param name="mono"></param>
    public void Request<Mono>(Mono mono) where Mono : MonoBehaviour
    {
        mono.StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        yield return _request.SendWebRequest();
        SheetJsonData data = JsonUtility.FromJson<SheetJsonData>(_request.downloadHandler.text);
        _action.Invoke(data);
    }
}
