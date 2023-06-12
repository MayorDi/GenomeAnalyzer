using System.Drawing;

namespace GenomeAnalyzer;

/// <summary>
/// Contains a basic description of the properties of a single cell.
/// </summary>
public class Gene : ICloneable
{
    #region Propertys

    /// <summary>
    /// Id is mode of cell.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// A property indicating the type of cell.
    /// </summary>
    public int CellType { get; set; }

    /// <summary>
    /// Sets the priority of the cell, namely whether it will remain alive with a shortage of energy.
    /// </summary>
    public bool Prioritize { get; set; }

    /// <summary>
    /// Is the cell the initial cell of the body from which everything will go.
    /// </summary>
    public bool Initial { get; set; }

    /// <summary>
    /// Creates adhesion between cells.
    /// </summary>
    public bool MakeAdhesin { get; set; }

    /// <summary>
    /// Determines the minimum mass for cell division.
    /// </summary>
    public float SplitMass { get; set; }

    /// <summary>
    /// Determines the ratio between getting the mass to each cell.
    /// </summary>
    public float SplitRatio { get; set; }

    /// <summary>
    /// Defines the angle in the direction of which the division will be performed.
    /// </summary>
    public float SplitAngle { get; set; }

    /// <summary>
    /// The angle that the daughter cell acquires after the division of the ancestor.
    /// </summary>
    public float Child1Angle { get; set; }

    /// <summary>
    /// The angle that the daughter cell acquires after the division of the ancestor.
    /// </summary>
    public float Child2Angle { get; set; }

    /// <summary>
    /// Sets the power priority for the cell, which determines the percentage of energy sent to this cell.
    /// </summary>
    public float NutrientPriority { get; set; }

    /// <summary>
    /// Defines the gene that will encode the next daughter cell.
    /// </summary>
    public int Child1Mode { get; set; }

    /// <summary>
    /// Defines the gene that will encode the next daughter cell.
    /// </summary>
    public int Child2Mode { get; set; }

    /// <summary>
    /// Determines the presence of adhesion in the daughter cell with the rest of the neighboring cells of the ancestor.
    /// </summary>
    public bool KeepAdhesin1 { get; set; }

    /// <summary>
    /// Determines the presence of adhesion in the daughter cell with the rest of the neighboring cells of the ancestor.
    /// </summary>
    public bool KeepAdhesin2 { get; set; }

    /// <summary>
    /// Produces a reflection of daughter cells relative to the ancestor.
    /// </summary>
    public bool Mirror1 { get; set; }

    /// <summary>
    /// Produces a reflection of daughter cells relative to the ancestor.
    /// </summary>
    public bool Mirror2 { get; set; }

    /// <summary>
    /// Determines the fixity of adhesion between cells.
    /// </summary>
    public float AdhesinStiffness { get; set; }

    /// <summary>
    /// Sets the color of the cell.
    /// </summary>
    public Color Color { get; set; }

    /// <summary>
    /// Specifies more specific cell settings.
    /// </summary>
    public SpecificSettings? SpecificSettings { get; set; }

    #endregion

    #region Constructor

    public Gene() { }

    public Gene(int id, 
        int cellType, 
        bool prioritize, 
        bool initial, 
        bool makeAdhesin, 
        float splitMass, 
        float splitRatio, 
        float splitAngle, 
        float child1Angle, 
        float child2Angle, 
        float nutrientPriority, 
        int child1Mode, 
        int child2Mode, 
        bool keepAdhesin1, 
        bool keepAdhesin2, 
        bool mirror1, 
        bool mirror2, 
        float adhesinStiffness, 
        Color color, 
        SpecificSettings? specificSettings)
    {
        Id = id;
        CellType = cellType;
        Prioritize = prioritize;
        Initial = initial;
        MakeAdhesin = makeAdhesin;
        SplitMass = splitMass;
        SplitRatio = splitRatio;
        SplitAngle = splitAngle;
        Child1Angle = child1Angle;
        Child2Angle = child2Angle;
        NutrientPriority = nutrientPriority;
        Child1Mode = child1Mode;
        Child2Mode = child2Mode;
        KeepAdhesin1 = keepAdhesin1;
        KeepAdhesin2 = keepAdhesin2;
        Mirror1 = mirror1;
        Mirror2 = mirror2;
        AdhesinStiffness = adhesinStiffness;
        Color = color;
        SpecificSettings = specificSettings;
    }
    #endregion

    #region ImplsInterface

    public object Clone()
    {
        return (Gene)new(
            Id,
            CellType,
            Prioritize, Initial,
            MakeAdhesin, SplitMass,
            SplitRatio, SplitAngle, Child1Angle,
            Child2Angle, NutrientPriority,
            Child1Mode, Child2Mode,
            KeepAdhesin1, KeepAdhesin2,
            Mirror1, Mirror2,
            AdhesinStiffness,
            Color,
            (SpecificSettings?)SpecificSettings?.Clone()
        );
    }

    #endregion
}