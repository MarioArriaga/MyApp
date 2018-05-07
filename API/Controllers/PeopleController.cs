using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL.Entities;
using DAL.Infrastructure;
using DAL.Infrastructure.Repository;
using DAL.Interfaces;

namespace API.Controllers
{
    public class PeopleController : ApiController
    {
        private IPersonRepository repo = new PersonRepository();

        // GET: api/People
        public IQueryable<IPerson> GetPersons()
        {
            return repo.GetPerson().AsQueryable<IPerson>();
        }

        // GET: api/People/5
        [ResponseType(typeof(IPerson))]
        public IHttpActionResult GetPerson(int id)
        {
            IPerson person = repo.FindById(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, IPerson person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            //repo.Entry(person).State = EntityState.Modified;

            try
            {
                //repo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/People
        [ResponseType(typeof(IPerson))]
        public IHttpActionResult PostPerson(IPerson person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Add(person);
            //repo.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(IPerson))]
        public IHttpActionResult DeletePerson(int id)
        {
            IPerson person = repo.FindById(id);
            if (person == null)
            {
                return NotFound();
            }

            repo.Remove(person.Id.ToString());
            //repo.SaveChanges();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return repo.FindById(id) != null;
        }
    }
}