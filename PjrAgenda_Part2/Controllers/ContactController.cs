using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PjrAgenda_Part2.Context;
using PjrAgenda_Part2.Models;

namespace PjrAgenda_Part2.Controllers
{
    internal class ContactController
    {
        static public void InsertContact(Contact cont)
        {
            using (var context = new AgendaContext())
            {
                context.Contacts.Add(cont);
                context.SaveChanges();
            }
           
        }
        static public void PrintListContact()
        {
            using(var context = new AgendaContext())
            {
                var cont = new AgendaContext().Contacts.ToList();
                foreach (var item in cont)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadKey();
            }   
        }

        static public Contact SelectContact(string name)
        {
            Contact search = new AgendaContext().Contacts.FirstOrDefault(b=>b.Name==name);
            if (search != null)
            {
                Console.WriteLine(search.ToString());
            }
            return search;
        }
    }
}
