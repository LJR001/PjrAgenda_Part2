using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PjrAgenda_Part2.Context;
using PjrAgenda_Part2.Models;

namespace PjrAgenda_Part2.Controllers
{
    internal class TelephoneController
    {
        static public void InsertTelephone(Telephone tel)
        {
            using (var context = new AgendaContext())
            {
                context.Telephones.Add(tel);
                context.SaveChanges();
            }
           
        }
        static public void PrintListTelephone()
        {
            using (var context = new AgendaContext())
            {
                
                var tel = new AgendaContext().Telephones.ToList();
                foreach (var item in tel)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadKey();
            }
        }
        static public Telephone SelectTelephone(string name)
        {
            Telephone search = new AgendaContext().Telephones.FirstOrDefault(b => b.Name == name);

            if (search != null)
            {
                Console.WriteLine(search.ToString());
            }
            return search;
        }
        static public void UpdateTelephone(Telephone tel)
        {
            using (var context = new AgendaContext())
            {
                context.Entry(tel).State = EntityState.Modified;
                context.Telephones.AddOrUpdate(tel);
                context.SaveChanges();
            }
        }
        static public void RemoveTelephone(Telephone tel)
        {
            using (var context = new AgendaContext())
            {
                context.Entry(tel).State = EntityState.Deleted;
                context.Telephones.Remove(tel);
                context.SaveChanges();
            }
        }

    }
    
}
