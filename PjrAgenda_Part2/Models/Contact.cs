using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PjrAgenda_Part2.Models
{
    internal class Contact
    {
        [Key]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Contact()
        {

        }
        public override string ToString()
        {
            return "\n - - - - - - - - - - " +
                "\nNome:"+Name+"\n" +
                "Apelido: "+Surname+"\n" +
                "Email: "+Email;
        }
    }
}
