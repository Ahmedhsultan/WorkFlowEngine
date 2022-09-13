namespace WorkFlowEngine.Models.DTOs.Tasks
{
    public class ClientSubmitTaskDTO
    {
        public string taskGUID { get; set; }
        public string responseText { get; set; } = string.Empty;
        public bool response { get; set; } = true;
    }
}
