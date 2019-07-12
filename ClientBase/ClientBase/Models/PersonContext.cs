using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;

namespace ClientBase.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

    }

    public class PersonDbInitializer : DropCreateDatabaseIfModelChanges<PersonContext>
    {
        protected override void Seed(PersonContext context)
        {
            base.Seed(context);
        }
    }
}