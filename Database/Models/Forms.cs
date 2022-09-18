using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Forms
    {
        [Key]
        public Guid formGuid { get; set; }
        public string formName { get; set; }
        public string html { get; set; }
        public string json { get; set; }
        public DateTime createOn { get; set; } = DateTime.Now;
        public virtual ICollection<User> adminUsers { get; set; }
        public virtual ICollection<Processes> assumerProcesses { get; set; }
    }
}
