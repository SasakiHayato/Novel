using UnityEngine;

public abstract class ManagerBase : MonoBehaviour
{
    void Awake()
    {
        Setup();
    }

    void Start()
    {
        GameManager.Instance.AddManager(this, Name());
    }

    void OnDestroy()
    {
        Dispose();
    }

    protected abstract void Setup();
    protected abstract void Dispose();
    protected abstract string Name();
}
