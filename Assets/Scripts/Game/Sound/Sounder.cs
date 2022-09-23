using System.Collections;
using UnityEngine;

public class Sounder
{
    AudioSource _source;
    float _volume;
    SoundType _soundType;

    public bool IsUsing { get; private set; }

    public Sounder(Transform parent)
    {
        GameObject obj = new GameObject("Sounder");
        obj.transform.SetParent(parent);

        _source = obj.AddComponent<AudioSource>();
        IsUsing = false;
    }

    public void SetData(SoundData data, SoundType type)
    {
        _source.clip = data.AudioClip;
        _volume = data.Volume;
        _source.volume = SetVolume();
        _soundType = type;

        if (type == SoundType.BGM)
        {
            _source.loop = true;
        }
        else
        {
            _source.loop = false;
        }

        IsUsing = true;
    }

    public IEnumerator Play()
    {
        _source.Play();

        while (_source.isPlaying)
        {
            _source.volume = SetVolume();
            yield return null;
        }

        Delete();
    }

    float SetVolume()
    {
        float set = SoundMaster.MasterVolume * _volume;

        switch (_soundType)
        {
            case SoundType.BGM: set *= SoundMaster.BGMVolume;
                break;
            case SoundType.SE: set *= SoundMaster.SEVolume;
                break;
        }

        return set;
    }

    void Delete()
    {
        _source.clip = null;
        _volume = 0;
        IsUsing = false;
    }
}
