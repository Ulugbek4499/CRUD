using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Person
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string PersonalData { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return $"\nId:{Id},Name:{Name},PersonalData:{PersonalData},Login:{Login},Password:{Password}";
        }
    }
}
