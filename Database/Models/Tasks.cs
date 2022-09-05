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
        public string requestName { get; set; }
        public DateTime createOn { get; set; }
        public Guid processId { get; set; }
        public virtual Processes process { get; set; }

        //public User assigneeUser { get; set; }
        public virtual ICollection<User> outhUser { get; set; }
    }
}
