﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.API
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
