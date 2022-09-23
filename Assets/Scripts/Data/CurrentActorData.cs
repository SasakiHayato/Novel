using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentActorData
{
    public string Path { get; private set; }
    public string Name { get; private set; }

    public void SetPath(string path) => Path = path;
    public void SetName(string name) => Name = name;
}
