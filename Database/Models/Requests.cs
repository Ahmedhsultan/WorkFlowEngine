using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Requests
    {
        [Key]
        public Guid guid { get; set; }
        public User user { get; set; }
        public Processes startProcesses { get; set; }
    }
}
