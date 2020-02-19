using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Pomodoro_api.Data;
using Pomodoro_api.Models;

namespace Pomodoro_api.Controllers
{
    [RoutePrefix("api/Histories")]
    public class HistoriesController : ApiController
    {
        private PomodoroApiContext db = new PomodoroApiContext();

        // GET: api/Histories
        [Route("", Name = "GetHistories")]
        [HttpGet]
        public IQueryable<History> GetHistories()
        {
            return db.Histories;
        }

        // GET: api/Histories/5
        [Route("{id:int}", Name = "GetHistoryById")]
        [HttpGet]
        [ResponseType(typeof(History))]
        public async Task<IHttpActionResult> GetHistory(int id)
        {
            History history = await db.Histories.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }

            return Ok(history);
        }

        // PUT: api/Histories/5
        [Route("{id:int}", Name = "PutHistory")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHistory(int id, History history)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != history.Id)
            {
                return BadRequest();
            }

            db.Entry(history).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryExists(id))
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

        // POST: api/Histories
        [Route("", Name = "PostHistory")]
        [HttpPost]
        [ResponseType(typeof(History))]
        public async Task<IHttpActionResult> PostHistory(History history)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Histories.Add(history);
            await db.SaveChangesAsync();

            return CreatedAtRoute("GetHistoryById", new { id = history.Id }, history);
        }

        // DELETE: api/Histories/5
        [Route("{id:int}", Name = "DeleteHistory")]
        [HttpDelete]
        [ResponseType(typeof(History))]
        public async Task<IHttpActionResult> DeleteHistory(int id)
        {
            History history = await db.Histories.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }

            db.Histories.Remove(history);
            await db.SaveChangesAsync();

            return Ok(history);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoryExists(int id)
        {
            return db.Histories.Count(e => e.Id == id) > 0;
        }
    }
}