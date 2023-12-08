using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Warhammer_Army_Manager.Database.Tables
{
    internal class Weapons
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(7)]
        public string Type { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public int Range { get; set; }
        [MaxLength(5)]   
        public string Attacks { get; set; }
        [Required,MaxLength(2)]
        public string ToHit { get; set; }
        [Required, MaxLength(2)]
        public string ToWound { get; set; }
        public int? Rend { get; set; }
        [Required, MaxLength(5)]
        public string Damage { get; set; }
        public string? SpecialEffect { get; set; }

        public virtual ICollection<Unit> Units { get; private set; } = new ObservableCollection<Unit>();
    }
}

