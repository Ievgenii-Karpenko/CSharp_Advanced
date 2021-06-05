using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore_Connect
{
    public partial class Company
    {
        public Company()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
