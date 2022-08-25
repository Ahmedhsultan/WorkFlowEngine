using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Tasks
    {
        [Key]
        public Guid taskId { get; set; }
        public string taskName { get; set; }
        public Guid processId { get; set; }
        public Processes process { get; set; }
        public ICollection<User> outhUser { get; set; }
    }
}
