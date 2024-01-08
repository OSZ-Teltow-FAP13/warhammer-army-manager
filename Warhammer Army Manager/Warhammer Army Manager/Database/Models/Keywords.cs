﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Warhammer_Army_Manager.Database.Models
{
    internal class Keywords
    { 
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string? Keyword { get; set; }
        public virtual ICollection<Unit> Units { get; private set; } = new ObservableCollection<Unit>();
    }
}
