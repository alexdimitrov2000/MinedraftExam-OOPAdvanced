using System;

public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;

    private double durability;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability
    {
        get => durability;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Broken entity with ID: {this.ID}");
            }

            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= 100;
    }

    public double Produce()
    {
        return this.OreOutput;
    }

    public override string ToString()
    {
        return this.GetType().Name + Environment.NewLine + $"Durability: {this.Durability}";
    }
}