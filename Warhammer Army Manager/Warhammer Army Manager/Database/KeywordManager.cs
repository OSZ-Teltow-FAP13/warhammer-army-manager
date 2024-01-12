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
    class KeywordManager
    {
        public static ObservableCollection<Keyword> Keywords { get; set; } = new();

        public static ObservableCollection<Keyword> GetKeywords()
        {
            using (var context = new ApplicationDbContext())
            {
                foreach (Keyword t in context.Keywords.ToList())
                {
                    Keywords.Add(t);
                }
            }

            return Keywords;
        }
        public static void AddKeywords(Keyword keywords)
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
