using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entities
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public long Group_Id { get; set; }
        [ForeignKey("Group_Id")]
        public virtual Group Group { get; set; }
    }
}