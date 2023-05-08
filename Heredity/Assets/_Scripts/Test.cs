using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool test;
    public ColorGenotype Genotype;
    public List<Gene<Color>> a;
    public List<Gene<Color>> b;


    private void OnValidate()
    {
        if (!test) return;
        
        Genotype.Initialize(a, b);
        test = false;
    }
}