using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace GenomeAnalyzer;

/// <summary>
/// Collection of genes.
/// </summary>
public class Genome : IEnumerable, IList<Gene>
{
    public const int COUNT_GENES = 40;

    private Gene[] _genes;

    public int Count => _genes.Length;

    public bool IsReadOnly => throw new NotImplementedException();

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

    public int IndexOf(Gene item)
    {
        for (int i = 0; i < _genes.Length; i++)
        {
            Gene? gene = _genes[i];
            if (gene.GetHashCode() == item.GetHashCode())
                return i;
        }

        return -1;
    }

    public void Insert(int index, Gene item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public void Add(Gene item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(Gene item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Gene[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(Gene item)
    {
        throw new NotImplementedException();
    }

    IEnumerator<Gene> IEnumerable<Gene>.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}