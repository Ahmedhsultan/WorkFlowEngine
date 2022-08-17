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
        public Guid Id { get; set; }
        public string DigramName { get; set; }
    }
}
