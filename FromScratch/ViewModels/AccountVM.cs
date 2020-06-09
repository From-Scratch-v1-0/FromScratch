using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FromScratch.ViewModels
{
    public class AccountVM
    {
        public LogInVM Login { get; set; }
        public SignUpVM Signup { get; set; }
    }
}
