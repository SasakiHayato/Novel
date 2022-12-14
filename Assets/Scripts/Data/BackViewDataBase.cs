using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BackViewData")]
public class BackViewDataBase : ScriptableObject
{
    [SerializeField] List<BackViewData> _backViewDataList;

    public Sprite GetData(string path)
    {
        try
        {
            BackViewData data = _backViewDataList.First(d => d.Path == path);
            return data.Sprite;
        }
        catch
        {

            Debug.Log($"一致する背景データがありませんでした。{path} is not found");
            return null;
        }
    }
}
