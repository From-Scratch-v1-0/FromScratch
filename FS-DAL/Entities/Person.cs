using System;
using System.Collections.Generic;
using System.Text;

namespace FS_DAL.Entities
{
    public partial class Person
    {
        public string? UserKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? Age { get; set; }
        public int? GenderKey { get; set; }
        public int? CountryKey { get; set; }
        public string Address { get; set; }

        public virtual Country CountryKeyNavigation { get; set; }
        public virtual Gender GenderKeyNavigation { get; set; }
        public virtual User UserKeyNavigation { get; set; }
    }
}
