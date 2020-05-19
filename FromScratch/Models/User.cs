using System;
using System.Collections.Generic;

namespace FromScratch.Models
{
    public partial class User
    {
        public int UserKey { get; set; }
        public DateTime? CreateDate { get; set; }
        public short? UserTypeKey { get; set; }
        public bool? IsActive { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Rating { get; set; }

        public virtual UserType UserTypeKeyNavigation { get; set; }
    }
}
