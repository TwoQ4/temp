using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WpfApp2.model
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public override string ToString()
        {
            var res = "";
            res += Id != null ? Id.ToString() + " " : "";
            res += Name != null && Name.Length > 0 ? Name.Substring(0, 1) + " " : "";
            return res;
        }

    }
}
