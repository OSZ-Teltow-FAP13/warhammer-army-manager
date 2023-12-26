using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warhammer_Army_Manager.Models;

namespace Warhammer_Army_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {              
            addSampleData();
        }

        private static void addSampleData()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();

                string unitName = "187 Pferde der Beflügelung";
                if (!context.Units.Any(unit => unit.Name == unitName))
                {
                    var unitHorses = new Unit
                    {
                        Name = unitName,
                        Description = "Eines Tages waren 1337 Pferde auf der Weide am grasen. Dann kamen 69 Einhörnchen und spießten 1150 Pferde auf davon wurden 420 Pferde so verletzt das sie direkt drauf gingen. Die anderen 3.14 sind erst nach Stunden leiden verblutet. Die verbleibenden 187 Pferde kämpfen von nun an gegen die Einhörnchen. Die 8.589.869.056 ist die sechste vollkommene Zahl, 1588 von Cataldi entdeckt. Für weitere Detils: https://de.wikipedia.org/wiki/Liste_besonderer_Zahlen",
                        Health = 10,
                        Mobillity = 8,
                        Courage = 9,
                        Protection = 1,
                    };
                    context.Units.Add(unitHorses);
                }

                if (!context.Tags.Any(tag => tag.Name == "Tag01"))
                {
                    var tagTest = new Tag
                    {
                        Name = "Tag01",
                        Slug = "tag-01"
                    };
                    context.Tags.Add(tagTest);
                }

                context.SaveChanges();
            }
        }
    }
}
