using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore_Connect
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompanyId { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }

        public virtual Company Company { get; set; }
    }
}
