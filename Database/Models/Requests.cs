using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Requests
    {
        [Key]
        public Guid requsetId { get; set; }
        public Guid userId { get; set; }
        public Guid startProcessesId { get; set; }
        public User user { get; set; }
        public Processes startProcesses { get; set; }
    }
}
