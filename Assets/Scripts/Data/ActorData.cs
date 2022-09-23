using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum FaceType
{
    Default,
    Silhouette,
}

[System.Serializable]
public class ActorData 
{
    [SerializeField] List<FaceData> _faceDataList;

    public Sprite GetSprite(FaceType faceType)
    {
        try
        {
            FaceData data = _faceDataList.First(d => d.FaceType == faceType);
            return data.Sprite;
        }
        catch
        {
            Debug.Log($"一致する表情データがありませんでした。{faceType} is not found");
            return null;
        }
    }

    [System.Serializable]
    class FaceData
    {
        [SerializeField] FaceType _faceType;
        [SerializeField] Sprite _sprite;

        public FaceType FaceType => _faceType;
        public Sprite Sprite => _sprite;
    }
}
