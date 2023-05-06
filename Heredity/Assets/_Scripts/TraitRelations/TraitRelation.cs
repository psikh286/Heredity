using UnityEngine;

public abstract class TraitRelation<T> : ScriptableObject
{
    public Trait<T> Dominant;
    public Trait<T> Recessive;
}