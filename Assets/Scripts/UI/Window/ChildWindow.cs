using UnityEngine;

public abstract class ChildWindow : MonoBehaviour
{
    [SerializeField] string _path;

    public string Path => _path;

    void Awake()
    {
        Setup();
    }

    protected abstract void Setup();

    public void Active(bool isActive)
    {
        Debug.Log(isActive);
        gameObject.SetActive(isActive);
    }

    public abstract void CallBack(object[] data);
}
