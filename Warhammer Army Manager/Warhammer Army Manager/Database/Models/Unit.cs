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

namespace Warhammer_Army_Manager.Database.Models
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
        public int Points { get; set; }

        public virtual ICollection<Keyword> Keywords { get; private set; } = new ObservableCollection<Keyword>();
        public virtual ICollection<Weapon> Weapons { get; private set; } = new ObservableCollection<Weapon>();
        public virtual ICollection<Army> Armys { get; private set; } = new ObservableCollection<Army>();

    }
}
