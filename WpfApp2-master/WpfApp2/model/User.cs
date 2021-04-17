using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WpfApp2.model;

namespace WpfApp2.model
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public Ticket Ticket { get; set; }

        public override string ToString()
        {
            var res = "";
            res += Id != null ? Id.ToString() + " " : "";
            res += LastName != null && LastName.Length > 0 ? LastName.Substring(0, 1) + " " : "";
            res += FirstName != null && FirstName.Length > 0 ? FirstName.Substring(0, 1) + ". " : "";
            res += MiddleName != null && MiddleName.Length > 0 ? MiddleName.Substring(0, 1) + "." : "";
            return res;
        }
    }
}
