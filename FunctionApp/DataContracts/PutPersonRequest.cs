using System;

namespace FunctionApp.DataContracts
{
    public class PutPersonRequest
    {
        public string ExternalId { get; set; }

        public string Name { get; set; }
    }
}