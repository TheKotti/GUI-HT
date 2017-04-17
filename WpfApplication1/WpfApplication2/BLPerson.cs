using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
