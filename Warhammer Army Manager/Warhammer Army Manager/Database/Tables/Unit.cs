using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Warhammer_Army_Manager.Database.Tables
{
    internal class Unit
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        public int Wounds { get; set; }
        public int Move { get; set; }
        public int Bravery { get; set; }
        [Required, MaxLength(2)]
        public string? Save { get; set; }

        public virtual ICollection<Keywords> Keywords { get; private set; } = new ObservableCollection<Keywords>();
        public virtual ICollection<Weapons> Weapons { get; private set; } = new ObservableCollection<Weapons>();

    }
}
