public struct SoundRequester
{
    public string Path { get; private set; }
    public SoundType SoundType { get; private set; }

    public SoundRequester SetPath(string path)
    {
        Path = path;
        return this;
    }

    public SoundRequester SetType(SoundType type)
    {
        SoundType = type;
        return this;
    }

    public void IsRequest()
    {
        SoundManager manager = GameManager.Instance.GetManager<SoundManager>(nameof(SoundManager));
        manager.Request(this);
    }
}
