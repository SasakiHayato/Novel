using UnityEngine;

public abstract class UIModel : MonoBehaviour
{
    [SerializeField] string _path;

    public string Path => _path;

    void Start()
    {
        Setup();
    }

    protected abstract void Setup();

    public abstract void CallBack();
}
