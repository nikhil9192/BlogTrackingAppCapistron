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
    public class AdminInfoesController : ApiController
    {
        private BlogContext db = new BlogContext();

        // GET: api/AdminInfoes
        public IQueryable<AdminInfo> GetAdminInfos()
        {
            return db.AdminInfos;
        }

        // GET: api/AdminInfoes/5
        [ResponseType(typeof(AdminInfo))]
        public IHttpActionResult GetAdminInfo(int id)
        {
            AdminInfo adminInfo = db.AdminInfos.Find(id);
            if (adminInfo == null)
            {
                return NotFound();
            }

            return Ok(adminInfo);
        }

        // PUT: api/AdminInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdminInfo(int id, AdminInfo adminInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adminInfo.AdminInfoId)
            {
                return BadRequest();
            }

            db.Entry(adminInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminInfoExists(id))
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

        // POST: api/AdminInfoes
        [ResponseType(typeof(AdminInfo))]
        public IHttpActionResult PostAdminInfo(AdminInfo adminInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdminInfos.Add(adminInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adminInfo.AdminInfoId }, adminInfo);
        }

        // DELETE: api/AdminInfoes/5
        [ResponseType(typeof(AdminInfo))]
        public IHttpActionResult DeleteAdminInfo(int id)
        {
            AdminInfo adminInfo = db.AdminInfos.Find(id);
            if (adminInfo == null)
            {
                return NotFound();
            }

            db.AdminInfos.Remove(adminInfo);
            db.SaveChanges();

            return Ok(adminInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminInfoExists(int id)
        {
            return db.AdminInfos.Count(e => e.AdminInfoId == id) > 0;
        }
    }
}