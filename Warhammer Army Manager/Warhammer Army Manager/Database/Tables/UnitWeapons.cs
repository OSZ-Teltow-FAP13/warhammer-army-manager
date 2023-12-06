using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warhammer_Army_Manager.Database.Tables
{
    internal class UnitWeapons
    {
        public int Id { get; set; }
        public int UnitId {  get; set; }
        public int WeaponId { get; set; }
    }
}
