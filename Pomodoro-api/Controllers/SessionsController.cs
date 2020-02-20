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
    [RoutePrefix("api/Sessions")]
    public class SessionsController : ApiController
    {
        private PomodoroApiContext db = new PomodoroApiContext();

        // GET: api/Sessions
        [Route("", Name ="GetSessions")]
        [HttpGet]
        public IQueryable<Session> GetSessions()
        {
            return db.Sessions;
        }

        // GET: api/Sessions/5
        [Route("{id:int}", Name = "GetSessionById")]
        [HttpGet]
        [ResponseType(typeof(Session))]
        public async Task<IHttpActionResult> GetSession(int id)
        {
            Session session = await db.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        // GET: api/Sessions/5/Pomodoroes
        [Route("{id:int}/Pomodoroes", Name = "GetPomodoroesBySession")]
        [HttpGet]
        [ResponseType(typeof(Pomodoro))]
        public List<Pomodoro> GetPomodoroesBySession(int id)
        {
            List<Pomodoro> pomodoroes = new List<Pomodoro>();
            pomodoroes = (from pom in db.Pomodoroes where pom.SessionId == id select pom).ToList();

            return pomodoroes;
        }


        // PUT: api/Sessions/5
        [Route("{id:int}", Name = "PutSession")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSession(int id, Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != session.Id)
            {
                return BadRequest();
            }

            db.Entry(session).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
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

        // PUT: api/Sessions/5/Pomodoroes
        [Route("{id:int}/Pomodoroes", Name = "PutPomodoroesInSession")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPomodoroesInSession(int id, List<Pomodoro> pomodoros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pomodoros.ForEach(delegate (Pomodoro pomodoro) {
                db.Entry(pomodoro).State = EntityState.Modified;
            });

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
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

        // POST: api/Sessions
        [Route("", Name = "PostSession")]
        [HttpPost]
        [ResponseType(typeof(Session))]
        public async Task<IHttpActionResult> PostSession(Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            for(int i = 0; i < session.NbPomodoros; i++)
            {
                var pomodoro = new Pomodoro();
                pomodoro.Position = i;
                pomodoro.Session = session;
                db.Pomodoroes.Add(pomodoro);
            }

            db.Sessions.Add(session);
            await db.SaveChangesAsync();

            return CreatedAtRoute("GetSessionById", new { id = session.Id }, session);
        }

        // DELETE: api/Sessions/5
        [Route("{id:int}", Name = "DeleteSession")]
        [HttpDelete]
        [ResponseType(typeof(Session))]
        public async Task<IHttpActionResult> DeleteSession(int id)
        {
            Session session = await db.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            db.Sessions.Remove(session);
            await db.SaveChangesAsync();

            return Ok(session);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SessionExists(int id)
        {
            return db.Sessions.Count(e => e.Id == id) > 0;
        }
    }
}