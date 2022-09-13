using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Digrams
    {
        [Key]
        public Guid digramId { get; set; }
        public string digramName { get; set; }
        public string digramJson { get; set; }
        public DateTime createdOn { get; set; } = DateTime.Now;
        public virtual ICollection<User> adminUsers { get; set; }
        public virtual ICollection<Processes> processes { get; set; }
    }
}