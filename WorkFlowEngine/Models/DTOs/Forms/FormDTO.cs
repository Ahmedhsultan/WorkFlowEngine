namespace WorkFlowEngine.Models.DTOs.Forms
{
    public class FormDTO
    {
        public string userName { get; set; }
        public string formGuid { get; set; }
        public string htmlForm { get; set; }
        public string jsonForm { get; set; }
        public List<string> outhUsers { get; set; }
    }
}
