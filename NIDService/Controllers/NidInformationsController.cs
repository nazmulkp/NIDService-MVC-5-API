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
using NIDService.Models;
using EntityState = System.Data.EntityState;

namespace NIDService.Controllers
{
    public class NidInformationsController : ApiController
    {
        private NIDServiceContext db = new NIDServiceContext();

        // GET api/NidInformations
        public IQueryable<NidInformation> GetNidInformations()
        {
            return db.NidInformations;
        }

        // GET api/NidInformations/5
        [ResponseType(typeof(NidInformation))]
        public IHttpActionResult GetNidInformation(int id)
        {
            NidInformation nidinformation = db.NidInformations.Find(id);
            if (nidinformation == null)
            {
                return NotFound();
            }

            return Ok(nidinformation);
        }

        // PUT api/NidInformations/5
        public IHttpActionResult PutNidInformation(int id, NidInformation nidinformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nidinformation.NidInformationId)
            {
                return BadRequest();
            }

            db.Entry(nidinformation).State = (System.Data.Entity.EntityState) EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NidInformationExists(id))
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

        // POST api/NidInformations
        [ResponseType(typeof(NidInformation))]
        public IHttpActionResult PostNidInformation(NidInformation nidinformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NidInformations.Add(nidinformation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nidinformation.NidInformationId }, nidinformation);
        }

        // DELETE api/NidInformations/5
        [ResponseType(typeof(NidInformation))]
        public IHttpActionResult DeleteNidInformation(int id)
        {
            NidInformation nidinformation = db.NidInformations.Find(id);
            if (nidinformation == null)
            {
                return NotFound();
            }

            db.NidInformations.Remove(nidinformation);
            db.SaveChanges();

            return Ok(nidinformation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NidInformationExists(int id)
        {
            return db.NidInformations.Count(e => e.NidInformationId == id) > 0;
        }
    }
}