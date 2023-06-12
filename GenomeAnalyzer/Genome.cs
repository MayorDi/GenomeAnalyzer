using System.Collections;

namespace GenomeAnalyzer;

/// <summary>
/// Collection of genes.
/// </summary>
public class Genome : IEnumerable
{
    public const int COUNT_GENES = 40;

    private Gene[] _genes;

    public Gene this[int key]
    {
        get => _genes[key];
        set => _genes[key] = value;
    }

    public Genome()
    {
        _genes = new Gene[COUNT_GENES];
    }

    public Genome(Gene[] genes)
    {
        _genes = genes;
    }

    public GeneEnum GetEnumerator()
    {
        return new GeneEnum(_genes);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }
}