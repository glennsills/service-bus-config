namespace SbConfiguration;

public class Subscription : BaseQueue
{
    public Rule DefaultRule {get;set;} = new Rule();
}