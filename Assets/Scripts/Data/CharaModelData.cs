using UnityEngine;

public enum FaceType
{
    Default = 0,
    Silhouette = 1,
}

[CreateAssetMenu(fileName = "CharaModelData")]
public class CharaModelData : ScriptableObject
{
    [SerializeField] string _charaName;
    [SerializeField] Vector2 _offsetRect;
    [SerializeField] FaceData _faceData;

    public Vector2 OffsetRect => _offsetRect;

    public Sprite GetData(FaceType type)
    {
        return _faceData.Send(type);
    }

    [System.Serializable]
    public class FaceData
    {
        [SerializeField] Sprite _default;
        [SerializeField] Sprite _silhouette;

        public Sprite Send(FaceType type)
        {
            switch (type)
            {
                case FaceType.Default: return _default;
                case FaceType.Silhouette: return _silhouette;
            }

            return null;
        }
    }
}
