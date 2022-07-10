using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entities
{
    public class Group
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public Group()
        {
            People = new HashSet<Person>();
        }
    }
}