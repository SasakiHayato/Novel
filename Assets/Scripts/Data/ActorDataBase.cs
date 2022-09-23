using UnityEngine;

[CreateAssetMenu(fileName = "ActorData")]
public class ActorDataBase : ScriptableObject
{
    [SerializeField] string _path;
    [SerializeField] Vector2 _size;
    [SerializeField, Range(0, 180)] int _defaultDir; 
    [SerializeField] ActorData _actorData;

    public string Path => _path;
    public Vector2 Size => _size;
    public ActorData ActorData => _actorData;
}
