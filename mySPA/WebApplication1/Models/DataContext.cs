using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class DataContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DataContext():base("Default")
        {

        }
    }
}