using System;
using System.Collections.Generic;
using System.Text;

namespace Andro
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public string Enterprice { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronomic { get; set; }

        public DateTime DateofBirth { get; set; }
    }
}
