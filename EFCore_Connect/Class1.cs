using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Connect
{
    class Class1
    {
        public static void Main(string[] args)
        {
            using(helloappdbContext dbContext = new helloappdbContext())
            {
                var comps = dbContext.Companies;
                var comp = new Company() { Name = "Apple"};
                var user = new User() { Name = "Adam", Company = comp, Age = 30 };
                comp.Users.Add(user);

                comps.AddRange(comp, new Company() { Name = "Tesla"});

                dbContext.SaveChanges();
            }

        }
    }
}
