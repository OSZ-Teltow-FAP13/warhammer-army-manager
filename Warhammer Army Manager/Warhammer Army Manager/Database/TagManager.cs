using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Warhammer_Army_Manager.Models
{
    class TagManager
    {
        public static ObservableCollection<Tag> Tags { get; set; } = new();

        public static ObservableCollection<Tag> GetTags()
        {
            using (var context = new ApplicationDbContext())
            {
                foreach (Tag t in context.Tags.ToList())
                {
                    Tags.Add(t);
                }
            }

            return Tags;
        }
        public static void AddTags(Tag tag)
        {
            using (var context = new ApplicationDbContext())
            {
                Tags.Add(tag);
                
                context.Tags.Add(tag);
                context.SaveChanges();

            }
        }
    }
}
