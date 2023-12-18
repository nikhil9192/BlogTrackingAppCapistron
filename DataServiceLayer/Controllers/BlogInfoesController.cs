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
    public class BlogInfoesController : ApiController
    {
        private BlogContext db = new BlogContext();

        // GET: api/BlogInfoes
        public IQueryable<BlogInfo> GetBlogInfos()
        {
            return db.BlogInfos;
        }

        // GET: api/BlogInfoes/5
        [ResponseType(typeof(BlogInfo))]
        public IHttpActionResult GetBlogInfo(int id)
        {
            BlogInfo blogInfo = db.BlogInfos.Find(id);
            if (blogInfo == null)
            {
                return NotFound();
            }

            return Ok(blogInfo);
        }

        // PUT: api/BlogInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlogInfo(int id, BlogInfo blogInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blogInfo.BlogInfoId)
            {
                return BadRequest();
            }

            db.Entry(blogInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogInfoExists(id))
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

        // POST: api/BlogInfoes
        [ResponseType(typeof(BlogInfo))]
        public IHttpActionResult PostBlogInfo(BlogInfo blogInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BlogInfos.Add(blogInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = blogInfo.BlogInfoId }, blogInfo);
        }

        // DELETE: api/BlogInfoes/5
        [ResponseType(typeof(BlogInfo))]
        public IHttpActionResult DeleteBlogInfo(int id)
        {
            BlogInfo blogInfo = db.BlogInfos.Find(id);
            if (blogInfo == null)
            {
                return NotFound();
            }

            db.BlogInfos.Remove(blogInfo);
            db.SaveChanges();

            return Ok(blogInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlogInfoExists(int id)
        {
            return db.BlogInfos.Count(e => e.BlogInfoId == id) > 0;
        }
    }
}