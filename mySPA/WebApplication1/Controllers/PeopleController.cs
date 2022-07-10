using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;
using WebApplication1.Models.DTO;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    
    public class PeopleController : BaseController
    {
        [HttpGet]
        public IHttpActionResult PeopleGet(long Id)
        {
            try
            {
                var myPerson = Context.People.Find(Id);
                return Ok(new DTOPerson() { Id = myPerson.Id, Name = myPerson.Name, Family = myPerson.Family, Group_Id = myPerson.Group_Id, Group = new DTOGroup() { Id = myPerson.Group.Id, Title = myPerson.Group.Title } });
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        [HttpGet]
        public IHttpActionResult PeopleGet()
        {
            try
            {
                var Data = Context.People.Include("Group").ToList().Select(myPerson => new DTOPerson() { Id = myPerson.Id, Name = myPerson.Name, Family = myPerson.Family, Group_Id = myPerson.Group_Id, Group = new DTOGroup() { Id = myPerson.Group.Id, Title = myPerson.Group.Title } });
                return Ok(Data);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        [HttpPost]
        public IHttpActionResult PeoplePost(Person myPerson)
        {
            try
            {
                Context.People.Add(myPerson);
                Context.SaveChanges();
                return Ok(new DTOPerson() { Id = myPerson.Id, Name = myPerson.Name, Family = myPerson.Family, Group_Id = myPerson.Group_Id, Group = new DTOGroup() { Id = myPerson.Group_Id, Title = Context.Groups.Find(myPerson.Group_Id).Title } });
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult PeoplePut(Person myPerson)
        {
            try
            {
                Context.Entry<Person>(myPerson).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return Ok(new DTOPerson() { Id = myPerson.Id, Name = myPerson.Name, Family = myPerson.Family, Group_Id = myPerson.Group_Id, Group = new DTOGroup() { Id = myPerson.Group_Id, Title = Context.Groups.Find(myPerson.Group_Id).Title } });
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult PeopleDelete(long Id)
        {
            try
            {
                Context.People.Remove(Context.People.Find(Id));
                Context.SaveChanges();
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        
    }
}