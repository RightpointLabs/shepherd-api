using System;

namespace FunctionApp.Contracts
{
    public class PutPersonRequest
    {
        public string ExternalId { get; set; }

        public string Name { get; set; }
    }
}