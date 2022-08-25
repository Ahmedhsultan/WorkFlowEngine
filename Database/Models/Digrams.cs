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
        public ICollection<User> adminUsers { get; set; }
        public ICollection<Processes> processes { get; set; }
    }
}