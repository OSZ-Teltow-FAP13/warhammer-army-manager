using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Warhammer_Army_Manager.Models
{
    internal class Unit
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Health { get; set; }
        public int Mobillity { get; set; }
        public int Courage { get; set; }
        public int Protection { get; set; }
        public bool isChampion { get; set; }

        public virtual ICollection<Tag> Tag { get; private set; } = new ObservableCollection<Tag>();

    }
}
