using UnityEngine;

[CreateAssetMenu(fileName = "CharaModelData")]
public class CharaModelData : ScriptableObject
{
    [SerializeField] ModelData _modelData;

    public ModelData GetData => _modelData;

    [System.Serializable]
    public class ModelData
    {
        [SerializeField] Sprite _default;
    }
}
