using Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class RunningRequests
    {
        [Key]
        public Guid runningRequeststId { get; set; }
        public string requestName { get; set; }
        public Status status { get; set; }
        public DateTime createOn { get; set; }
        public virtual User assigneeUser { get; set; }
        public Guid taskId { get; set; }
        public virtual Tasks task { get; set; }
    }
}
