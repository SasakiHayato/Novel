using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SoundType
{
    BGM,
    SE,
}

[CreateAssetMenu(fileName = "SoundData")]
public class SoundDataBase : ScriptableObject
{
    [SerializeField] SoundType _soundType;
    [SerializeField] List<SoundData> _soundDataList;

    public SoundType SoundType => _soundType;
    public SoundData GetData(string path)
    {
        try
        {
            return _soundDataList.First(s => s.Path == path);
        }
        catch
        {
            Debug.Log($"一致するサウンドデータだありませんでした。{path} is not found");
            return null;
        }
    }
}
