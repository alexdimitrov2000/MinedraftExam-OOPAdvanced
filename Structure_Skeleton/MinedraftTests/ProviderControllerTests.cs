using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class ProviderControllerTests
{
    private EnergyRepository energyRepository;
    private ProviderController providerController;

    [SetUp]
    public void SetUpProviderController()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
    }

    [Test]
    public void ProducesCorrectAmountOfEnergy()
    {
        List<string> firstProvider = new List<string>
        {
            "Solar", "1", "100"
        };

        List<string> secondProvider = new List<string>
        {
            "Solar", "2", "100"
        };

        this.providerController.Register(firstProvider);
        this.providerController.Register(secondProvider);
    }

    [Test]
    public void BrokenProviderIsDeleted()
    {
        List<string> firstProvider = new List<string>
        {
            "Solar", "1", "100"
        };

        this.providerController.Register(firstProvider);

        for (int i = 0; i < 8; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }
}