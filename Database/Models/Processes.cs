﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class Processes
    {
        [Key]
        public Guid processId { get; set; }
        public Guid formId { get; set; }
        public Guid scriptId { get; set; }
        public bool start { get; set; }
        public bool end { get; set; }
        public Guid nextProcessIdNo1 { get; set; }
        public Guid nextProcessIdNo2 { get; set; }
        public Guid digramId { get; set; }
        public virtual Digrams digram { get; set; }
        public virtual Requests request { get; set; }
        public virtual Tasks task { get; set; }
        public virtual ICollection<User> outhUser { get; set; }
    }
}