using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DTO
{
    public class DTOPerson
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public long Group_Id { get; set; }
        public DTOGroup Group { get; set; }
    }
}