using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string? Name { get; set; }
        public int Wounds { get; set; }
        public int Move { get; set; }
        public int Bravery { get; set; }
        public int Save { get; set; }

        public virtual ICollection<Keywords> Tag { get; private set; } = new ObservableCollection<Keywords>();

    }
}
