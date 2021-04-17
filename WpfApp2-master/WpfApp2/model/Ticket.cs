using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WpfApp2.model
{
    public class Ticket
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
