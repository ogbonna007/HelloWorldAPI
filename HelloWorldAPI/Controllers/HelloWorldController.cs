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
using HelloWorldAPI.Models;

namespace HelloWorldAPI.Controllers
{
    public class HelloWorldController : ApiController
    {
        private PerseusEntities db = new PerseusEntities();
        private List<helloworldinvariouslanguage> helloWord = new List<helloworldinvariouslanguage>();

        public HelloWorldController()
        {

        }

        public HelloWorldController(List<helloworldinvariouslanguage> helloWorldList)
        {
            this.helloWord = helloWorldList;
        }

        // GET: api/helloworldinvariouslanguages
        public IQueryable<helloworldinvariouslanguage> Gethelloworldinvariouslanguages()
        {
            return db.helloworldinvariouslanguages;
        }

        // GET: api/helloworldinvariouslanguages/5
        [ResponseType(typeof(helloworldinvariouslanguage))]
        public IHttpActionResult Gethelloworldinvariouslanguage(int id)
        {
            helloworldinvariouslanguage helloworldinvariouslanguage = db.helloworldinvariouslanguages.Find(id);
            if (helloworldinvariouslanguage == null)
            {
                return NotFound();
            }
            return Ok(helloworldinvariouslanguage);
        }

        // PUT: api/helloworldinvariouslanguages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puthelloworldinvariouslanguage(int id, helloworldinvariouslanguage helloworldinvariouslanguage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != helloworldinvariouslanguage.Id)
            {
                return BadRequest();
            }

            db.Entry(helloworldinvariouslanguage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!helloworldinvariouslanguageExists(id))
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

        // POST: api/helloworldinvariouslanguages
        [ResponseType(typeof(helloworldinvariouslanguage))]
        public IHttpActionResult Posthelloworldinvariouslanguage(helloworldinvariouslanguage helloworldinvariouslanguage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.helloworldinvariouslanguages.Add(helloworldinvariouslanguage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = helloworldinvariouslanguage.Id }, helloworldinvariouslanguage);
        }

        // DELETE: api/helloworldinvariouslanguages/5
        [ResponseType(typeof(helloworldinvariouslanguage))]
        public IHttpActionResult Deletehelloworldinvariouslanguage(int id)
        {
            helloworldinvariouslanguage helloworldinvariouslanguage = db.helloworldinvariouslanguages.Find(id);
            if (helloworldinvariouslanguage == null)
            {
                return NotFound();
            }

            db.helloworldinvariouslanguages.Remove(helloworldinvariouslanguage);
            db.SaveChanges();

            return Ok(helloworldinvariouslanguage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool helloworldinvariouslanguageExists(int id)
        {
            return db.helloworldinvariouslanguages.Count(e => e.Id == id) > 0;
        }
    }
}