﻿using System.ComponentModel.DataAnnotations;

namespace WorkFlowEngine.Models.DTOs.ProccesDigram
{
    public class DigramDTO
    {
        public string userName { get; set; }
        public Guid digramId { get; set; } = Guid.NewGuid();
        //[Required]
        public string digramName { get; set; }
        public List<string> adminUserName { get; set; }
        public List<string> initiateUserName { get; set; }
        [Required]
        public List<ProcessDTO> ProcessList { get; set; }
    }
}
