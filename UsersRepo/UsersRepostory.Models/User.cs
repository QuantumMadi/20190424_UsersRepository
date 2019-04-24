using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRepostory.Models
{
    public class User : Entity
    {
        public string Login { get; set; }
        public int HashPassword { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Admin { get; set; }
    }
}
