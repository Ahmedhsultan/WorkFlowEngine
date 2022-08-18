﻿using Database.Models.Enums;
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
        public Guid Id { get; set; }
        public string userName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSult { get; set; }
        public string Name { get; set; }
        public DateTime createdOn { get; set; }
        public Gender gender { get; set; }
        public Roles role { get; set; }
    }
}