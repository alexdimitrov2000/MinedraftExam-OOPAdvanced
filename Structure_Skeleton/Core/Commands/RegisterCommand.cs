using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController) : base(args)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string entityType = this.Arguments[0];

        string result = string.Empty;

        if (entityType == nameof(Harvester))
        {
            result = this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else if (entityType == nameof(Provider))
        {
            result = this.providerController.Register(this.Arguments.Skip(1).ToList());
        }

        return result;
    }
}