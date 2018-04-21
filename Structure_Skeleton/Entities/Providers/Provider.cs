using System;

public abstract class Provider : IProvider
{
    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = Constants.DefaultDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; protected set; }

    public double Durability
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
        this.Durability -= Constants.DurabilityDecrease;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return this.GetType().Name + Environment.NewLine + $"Durability: {this.Durability}";
    }
}