using System;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// �X�v���b�h�V�[�g����̃f�[�^���󂯎��
/// </summary>
public class WebRequester
{
    Action<SheetJsonData> _action;
    UnityWebRequest _request;

    const string HTTP = "https://script.google.com/macros/s/";
    const string DeployID = "AKfycbyvo916dNYdhRmipoaD6vvBpkOQ9OUEpZpNI4FHm8aLXNtnmsA9kpT9dALOXYcFSZiz";

    /// <summary>
    /// ���N�G�X�g�쐬
    /// </summary>
    /// <param name="sheetName">�󂯎��V�[�g�̖��O</param>
    /// <param name="action">�󂯎�����ۂ�Action</param>
    public WebRequester(string sheetName, Action<SheetJsonData> action)
    {
        string path = CreatePath(sheetName);

        _action = action;
        _request = UnityWebRequest.Get(path);
    }

    // �󂯎��V�[�g�p�X�̍쐬
    string CreatePath(string sheetName)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(HTTP + DeployID);
        builder.Append("/exec?sheet=");
        builder.Append(sheetName);

        return builder.ToString();
    }

    /// <summary>
    /// Web��֐\�����s��
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
