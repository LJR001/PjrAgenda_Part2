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
        #region INSERT
        static public void InsertTelephone(Telephone tel)
        {
            using (var context = new AgendaContext())
            {
                context.Telephones.Add(tel);
                context.SaveChanges();
            }
           
        }
        #endregion

        #region CONSULT
        static public void PrintListTelephone()
        {
            using (var context = new AgendaContext())
            {
                
                var tel = new AgendaContext().Telephones.ToList();
                if (tel.Count>0)
                {
                    foreach (var item in tel)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                else
                    Console.WriteLine(" A lista de contato está vazia");
            }
        }
        
        static public Telephone SelectTelephone(string name)
        {
            Telephone search = new AgendaContext().Telephones.FirstOrDefault(b => b.Name == name);

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
        static public void UpdateTelephone(Telephone tel)
        {
            using (var context = new AgendaContext())
            {
                context.Entry(tel).State = EntityState.Modified;
                context.Telephones.AddOrUpdate(tel);
                context.SaveChanges();
            }
        }
        #endregion

        #region REMOVE
        static public void RemoveTelephone(Telephone tel)
        {
            using (var context = new AgendaContext())
            {
                context.Entry(tel).State = EntityState.Deleted;
                context.Telephones.Remove(tel);
                context.SaveChanges();
            }
        }
        #endregion

    }

}
