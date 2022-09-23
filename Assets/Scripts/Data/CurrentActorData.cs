using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentActorData
{
    public string ActorKey { get; private set; }
    public string ViewName { get; private set; }
    public FaceType FaceType { get; private set; }
    public PositionType PositionType { get; private set; }

    public void SetActorKey(string path) => ActorKey = path;
    public void SetViewName(string name) => ViewName = name;
    public void SetFaceType(FaceType faceType) => FaceType = faceType;
    public void SetPosition(PositionType positionType) => PositionType = positionType;
}
