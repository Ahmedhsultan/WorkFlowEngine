using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class FormVariable
    {
        [Key]
        public Guid FormVariablesGUID { get; set; }
        public string Key { get; set; }
        public string value { get; set; }
        public Guid taskId { get; set; }
        public virtual Tasks task { get; set; }
    }
}
