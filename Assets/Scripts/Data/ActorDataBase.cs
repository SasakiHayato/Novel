using UnityEngine;

[CreateAssetMenu(fileName = "ActorData")]
public class ActorDataBase : ScriptableObject
{
    [SerializeField] ActorData _actorData;

    public ActorData ActorData => _actorData;
}
