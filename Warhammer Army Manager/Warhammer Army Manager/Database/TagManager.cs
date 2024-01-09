using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Warhammer_Army_Manager.Database.Models;

namespace Warhammer_Army_Manager.Database
{
    class TagManager
    {
        public static ObservableCollection<Keywords> Keywords { get; set; } = new();

        public static ObservableCollection<Keywords> GetKeywords()
        {
            using (var context = new ApplicationDbContext())
            {
                foreach (Keywords t in context.Keywords.ToList())
                {
                    Keywords.Add(t);
                }
            }

            return Keywords;
        }
        public static void AddKeywords(Keywords keywords)
        {
            using (var context = new ApplicationDbContext())
            {
                Keywords.Add(keywords);
                
                context.Keywords.Add(keywords);
                context.SaveChanges();

            }
        }
    }
}
