using UnityEngine;

public abstract class Gene<T> : ScriptableObject
{
    public Trait<T> Dominant;
    public Trait<T> Recessive;
}