using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Warhammer_Army_Manager.Database.Tables
{
    internal class Weapons
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Range { get; set; }
        public string Attacks { get; set; }
        public string ToHit { get; set; }
        public string ToWound { get; set; }
        public int? Rend { get; set; }
        public string Damage { get; set; }
        public string? SpecialEffect { get; set; }
    }
}

