using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Genotype<T> : MonoBehaviour
{
    private readonly List<Gene<T>> _genes = new();
    public List<Gene<T>> Genes => _genes;

    public void Initialize(List<Gene<T>> a, List<Gene<T>> b)
    {
        var aDic = a.ToDictionary(k => k.Relation, v => v.Dom);
        var bDic = b.ToDictionary(k => k.Relation, v => v.Dom);

        var matches = aDic.Keys.Intersect(bDic.Keys);
        
        foreach (var match in matches)
        {
            var seq = $"{RandomAllele(aDic[match])}{RandomAllele(bDic[match])}";
            if (seq == "aA") seq = "Aa";

            Enum.TryParse(seq, out AllelePair domination);
            
            var gene = new Gene<T>(domination, match);
            _genes.Add(gene);
            print($"Gene: {gene.Relation}  Dom: {gene.Dom}");

            char RandomAllele(AllelePair pair)
            {
                var result = pair switch
                {
                    AllelePair.AA => 'A',
                    AllelePair.Aa => Utility.RandomInt(0, 2) == 0 ? 'a' : 'A',
                    AllelePair.aa => 'a',
                    _ => throw new ArgumentOutOfRangeException(nameof(pair))
                };

                return result;
            }
        }
    }
}