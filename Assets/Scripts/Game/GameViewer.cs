using UnityEngine;

public class GameViewer : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.Setup();
    }

    private void Update()
    {
        
    }

    private void OnDestroy()
    {
        GameManager.Instance.Dispose();
    }
}
