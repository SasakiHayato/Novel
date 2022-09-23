using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : ManagerBase
{
    [SerializeField] int _sounderCount;
    [SerializeField, Range(0, 1)] float _masterVolume;
    [SerializeField, Range(0, 1)] float _bgmVolume;
    [SerializeField, Range(0, 1)] float _seVolume;
    [SerializeField] List<SoundDataBase> _soundDataBaseList;

    List<Sounder> _sounderList;

    protected override ManagerBase Setup()
    {
        _sounderList = new List<Sounder>();

        for (int index = 0; index < _sounderCount; index++)
        {
            Sounder sounder = new Sounder(transform);
            _sounderList.Add(sounder);
        }

        SoundMaster.SetMasterVolume(_masterVolume);
        SoundMaster.SetBGMVolume(_bgmVolume);
        SoundMaster.SetSEVolume(_seVolume);

        return this;
    }

    public void Request(SoundRequester requester)
    {
        SoundDataBase dataBase = _soundDataBaseList.First(s => s.SoundType == requester.SoundType);
        SoundData data = dataBase.GetData(requester.Path);

        Sounder sounder = _sounderList.First(s => !s.IsUsing);
        sounder.SetData(data, dataBase.SoundType);

        StartCoroutine(sounder.Play());
    }

    protected override string Path() => nameof(SoundManager);
}
