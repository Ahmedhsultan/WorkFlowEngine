using Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class User
    {
        [Key]
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSult { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Roles role { get; set; }
        public DateTime createdOn { get; set; }
        public Gender gender { get; set; }
        public virtual ICollection<Digrams> digrams { get; set; }
        public virtual ICollection<Requests> requests { get; set; }
        public virtual ICollection<Tasks> tasks { get; set; }
        public virtual ICollection<Processes> processes { get; set; }
        public virtual ICollection<RunningRequests> runningRequests { get; set; }
    }
}
