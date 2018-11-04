namespace FunctionApp.DataAccess.GraphSchema
{
    public interface IDomainMap<TDomain, TGraph>
    {
        TDomain ToDomain();

        TGraph FromDomain(TDomain model);
    }
}