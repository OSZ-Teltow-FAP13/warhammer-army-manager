using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Warhammer_Army_Manager.Database.Tables
{
    internal class Keywords
    { 
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        public virtual ICollection<Unit> Units { get; private set; } = new ObservableCollection<Unit>();
    }
}
