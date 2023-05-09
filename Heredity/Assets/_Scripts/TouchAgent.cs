using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorGenotype), typeof(IntGenotype), typeof(FloatGenotype))]
public class TouchAgent : MonoBehaviour
{
    [SerializeField] private ColorGenotype _colorGenotype;
    [SerializeField] private FloatGenotype _floatGenotype;
    [SerializeField] private IntGenotype _intGenotype;

    private TouchAgent prefab;
    

    private void Awake()
    {
        _colorGenotype = GetComponent<ColorGenotype>();
        _floatGenotype = GetComponent<FloatGenotype>();
        _intGenotype = GetComponent<IntGenotype>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.transform.CompareTag("Player")) return;
        if (!other.transform.TryGetComponent(out TouchAgent agent)) return;
        if (!agent.RequestMate()) return;
        
        agent.Reproduce(this);
    }

    private bool RequestMate()
    {
        return false;
    }

    private void Reproduce(TouchAgent mate)
    {
        var offspring = Instantiate(prefab, transform.position, Quaternion.identity);
        offspring._colorGenotype.Initialize(_colorGenotype.Genes, mate._colorGenotype.Genes);
        offspring._floatGenotype.Initialize(_floatGenotype.Genes, mate._floatGenotype.Genes);
        offspring._intGenotype.Initialize(_intGenotype.Genes, mate._intGenotype.Genes);
        offspring.gameObject.SetActive(true);
    }
}