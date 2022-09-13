namespace WorkFlowEngine.Models.Services.ProcessServices.CreateNodeList
{
    public class ProcessSecrviceDTO
    {
        public Guid processId { get; set; }
        public Guid formId { get; set; }
        public string Message { get; set; }
        public List<string> outhUser { get; set; }
        public Guid nextProcessIdNo1 { get; set; }
        public Guid nextProcessIdNo2 { get; set; }
    }
}
