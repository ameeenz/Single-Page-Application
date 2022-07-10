using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models.DTO;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class GroupController : BaseController
    {
        [HttpGet]
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                var Groups = Context.Groups.Include("People").Select(it => new DTOGroup() { Id = it.Id, Title = it.Title,CountPerson=it.People.Count });
                if (Groups.Count() < 1)
                {
                    return NotFound();
                }
                return Ok(Groups);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        // GET api/<controller>/5
        public IHttpActionResult Get(long id)
        {
            try
            {
                var model = Context.Groups.Find(id);
                return Ok(new DTOGroup() { Id= model.Id, Title= model.Title});
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post(Group model)
        {
            try
            {
                Context.Groups.Add(model);
                Context.SaveChanges();
                return Ok(new DTOGroup() { Id=model.Id, Title=model.Title});
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut]
        // PUT api/<controller>/5
        public IHttpActionResult Put(Group model)
        {
            try
            {
                Context.Entry<Group>(model).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return Ok(new DTOGroup() { Id = model.Id, Title = model.Title });
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete]
        // DELETE api/<controller>/5
        public IHttpActionResult Delete(long id)
        {
            try
            {
                Context.Groups.Remove(Context.Groups.Find(id));
                Context.SaveChanges();
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}