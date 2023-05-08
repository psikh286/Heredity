[System.Serializable]
public class Gene<T>
{
    public AllelePair Dom;
    public TraitRelation<T> Relation;

    public Gene(AllelePair domination, TraitRelation<T> relation)
    {
        Dom = domination;
        Relation = relation;
    }
}