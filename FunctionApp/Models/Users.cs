namespace FunctionApp.Models
{
    public class User : DbModelBase
    {
        public string Name { get; set; }

        public string TenantId { get; set; }
    }
}