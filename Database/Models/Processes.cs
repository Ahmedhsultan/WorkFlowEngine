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
        public Digrams digrams { get; set; }
        public string form { get; set; }
        public string script { get; set; }
        public ICollection<User> user { get; set; }
        public Guid nextProcessId { get; set; }
        public string divAttribute { get; set; }
    }
}
