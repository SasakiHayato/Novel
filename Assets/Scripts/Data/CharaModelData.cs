using UnityEngine;

public enum PictureType
{
    Default = 0,
    Silhouette = 1,
}

[CreateAssetMenu(fileName = "CharaModelData")]
public class CharaModelData : ScriptableObject
{
    [SerializeField] string _charaName;
    [SerializeField] PictureData _pictureData;

    public Sprite GetData(PictureType type)
    {
        return _pictureData.Send(type);
    }

    [System.Serializable]
    public class PictureData
    {
        [SerializeField] Sprite _default;
        [SerializeField] Sprite _silhouette;

        public Sprite Send(PictureType type)
        {
            switch (type)
            {
                case PictureType.Default: return _default;
                case PictureType.Silhouette: return _silhouette;
            }

            return null;
        }
    }
}
