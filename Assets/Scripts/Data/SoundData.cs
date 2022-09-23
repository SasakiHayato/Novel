using UnityEngine;

[System.Serializable]
public class SoundData 
{
    [SerializeField] string _path;
    [SerializeField] AudioClip _clip;
    [SerializeField, Range(0, 1)] float _volume;

    public string Path => _path;
    public AudioClip AudioClip => _clip;
    public float Volume => _volume;
}
