using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Processes
    {
        [Key]
        public Guid Id { get; set; }
        public Digrams digram { get; set; }
        public Guid form { get; set; }
        public Guid script { get; set; }
        public bool start { get; set; }
        public bool end { get; set; }
        public ICollection<User> user { get; set; }
        public Guid nextProcessIdNo1 { get; set; }
        public Guid nextProcessIdNo2 { get; set; }
    }
}
