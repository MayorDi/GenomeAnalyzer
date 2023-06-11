using System.Collections;

namespace GenomeAnalyzer;

public class GeneEnum : IEnumerator
{
    private Gene[] _genes;
    private int _position = -1;

    object IEnumerator.Current => this.Current;

    public Gene Current
    {
        get
        {
            try
            {
                return _genes[_position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public GeneEnum(Gene[] genes)
    {
        _genes = genes;
    }

    public bool MoveNext()
    {
        _position++;
        return (_position < _genes.Length);
    }

    public void Reset()
    {
        _position = -1;
    }
}