using UnityEngine;

public abstract class Gene<T> : ScriptableObject
{
    public Trait<T> Trait;
}