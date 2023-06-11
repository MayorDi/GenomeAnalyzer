namespace GenomeAnalyzer;

/// <summary>
/// Specific properties of the cell.
/// </summary>
public class SpecificSettings : ICloneable
{
    #region Constructor

    public SpecificSettings() { }

    #endregion

    #region ImplsInterface

    public object Clone()
    {
        return new SpecificSettings();
    }

    #endregion
}