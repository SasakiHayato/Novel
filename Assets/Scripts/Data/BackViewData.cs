using UnityEngine;

[System.Serializable]
public class BackViewData
{
    [SerializeField] string _path;
    [SerializeField] Sprite _sprite;

    public string Path => _path;
    public Sprite Sprite => _sprite;
}
