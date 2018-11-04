namespace FunctionApp.DataContracts
{
    public class CreateTopicRequest
    {
        public string Title { get; set; }

        public string SuccessCriteria { get; set; }

        public string Requestor { get; set; }
    }
}