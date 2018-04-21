using System.Collections.Generic;

public class RepairCommand : Command
{
    private IProviderController providerController;

    public RepairCommand(IList<string> args, IProviderController providerController) : base(args)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        double value = double.Parse(this.Arguments[0]);
        string result = this.providerController.Repair(value);

        return result;
    }
}
