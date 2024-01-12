using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warhammer_Army_Manager.Commands;
using Warhammer_Army_Manager.Database;
using Warhammer_Army_Manager.Database.Models;
using Warhammer_Army_Manager.Views;

namespace Warhammer_Army_Manager.ViewModels
{
    class WeaponViewModel : ViewModel
    {
        public ObservableCollection<Weapon> Weapons { get; set; }

        public WeaponViewModel()
        {
            Weapons = new ObservableCollection<Weapon>();
            using (var context = new ApplicationDbContext())
            {
                foreach (Weapon t in context.Weapons.ToList())
                {
                    Weapons.Add(t);
                }
            }
        }
    }

   
}