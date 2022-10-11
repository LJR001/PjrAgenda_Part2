using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PjrAgenda_Part2.Models
{
    internal class Telephone
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        public Telephone()
        {

        }
        public override string ToString()
        {
            return "\n. . . . . .  . . . . . ." +
                "\nNome: "+Name+"\n" +
                "Telefone: "+Phone+"\n" +
                "Celular: "+Mobile;
        }
    }
}
