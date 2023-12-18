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
using BlogApp;
using BlogApp.Context;

namespace DataServiceLayer.Controllers
{
    public class EmpInfoesController : ApiController
    {
        private BlogContext db = new BlogContext();

        // GET: api/EmpInfoes
        public IQueryable<EmpInfo> GetEmpInfos()
        {
            return db.EmpInfos;
        }

        // GET: api/EmpInfoes/5
        [ResponseType(typeof(EmpInfo))]
        public IHttpActionResult GetEmpInfo(int id)
        {
            EmpInfo empInfo = db.EmpInfos.Find(id);
            if (empInfo == null)
            {
                return NotFound();
            }

            return Ok(empInfo);
        }

        // PUT: api/EmpInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpInfo(int id, EmpInfo empInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empInfo.EmpInfoId)
            {
                return BadRequest();
            }

            db.Entry(empInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpInfoExists(id))
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

        // POST: api/EmpInfoes
        [ResponseType(typeof(EmpInfo))]
        public IHttpActionResult PostEmpInfo(EmpInfo empInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpInfos.Add(empInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empInfo.EmpInfoId }, empInfo);
        }

        // DELETE: api/EmpInfoes/5
        [ResponseType(typeof(EmpInfo))]
        public IHttpActionResult DeleteEmpInfo(int id)
        {
            EmpInfo empInfo = db.EmpInfos.Find(id);
            if (empInfo == null)
            {
                return NotFound();
            }

            db.EmpInfos.Remove(empInfo);
            db.SaveChanges();

            return Ok(empInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpInfoExists(int id)
        {
            return db.EmpInfos.Count(e => e.EmpInfoId == id) > 0;
        }
    }
}