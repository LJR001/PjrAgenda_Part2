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
       
    internal class ContactController
    {
        #region INSERT
        static public void InsertContact(Contact cont)
        {
            using (var context = new AgendaContext())
            {
                context.Contacts.Add(cont);
                context.SaveChanges();
            }
        }
        #endregion

        #region CONSULT
        static public void PrintListContact()
        {
            using(var context = new AgendaContext())
            {
                var cont = new AgendaContext().Contacts.ToList();

                if (cont.Count > 0) {
                    foreach (var item in cont)
                    {
                        Console.WriteLine(item.ToString());
                    }
                  
                }                              
                else
                    Console.WriteLine(" A lista de contato está vazia");
            }
        }
        static public bool CheckContact(string name)
        {
            Contact search = new AgendaContext().Contacts.FirstOrDefault(b => b.Name == name);
            if(search == null)
            {
                return false;
            }
            else
                Console.WriteLine("Ja existe um contato com esse nome !!!");
            return true;
        }

        static public Contact SelectContact(string name)
        {
            Contact search = new AgendaContext().Contacts.FirstOrDefault(b=>b.Name==name);
            if (search != null)
            {
                Console.WriteLine(search.ToString());
            }
            else
                Console.WriteLine("\n Contato não encontrado");

            return search;
        }
        #endregion

        #region UPDATE
        static public void UpdateContact(Contact cont)
        {
            using (var context = new AgendaContext())
            {
                context.Entry(cont).State = EntityState.Modified;
                context.Contacts.AddOrUpdate(cont);
                context.SaveChanges();
            }
        }
        #endregion

        #region REMOVE
        static public void RemoveContact(Contact cont)
        {
            using (var context = new AgendaContext())
            {
                context.Entry(cont).State = EntityState.Deleted;
                context.Contacts.Remove(cont);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
