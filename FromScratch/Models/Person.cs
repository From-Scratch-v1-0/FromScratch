using System;
using System.Collections.Generic;

namespace FromScratch.Models
{
    public partial class Person
    {
        public int? UserKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public short? Age { get; set; }
        public short? GenderKey { get; set; }
        public short? CountryKey { get; set; }
        public string Address { get; set; }

        public virtual Country CountryKeyNavigation { get; set; }
        public virtual Gender GenderKeyNavigation { get; set; }
        public virtual User UserKeyNavigation { get; set; }
    }
}
