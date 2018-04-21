public class PressureProvider : Provider
{
    public PressureProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.EnergyOutput *= 2;
        this.Durability -= 300;
    }
}