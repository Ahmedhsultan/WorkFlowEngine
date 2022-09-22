namespace WorkFlowEngine.Models.DTOs.Forms
{
    public class PostForm
    {
        public string userName { get; set; }
        public string formName { get; set; }
        public string htmlForm { get; set; }
        public string jsonForm { get; set; }
        public List<string> adminUsers { get; set; }
    }
}
