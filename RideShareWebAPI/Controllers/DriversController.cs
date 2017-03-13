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
using RideShare.DAL;
using System.Web.Http.Cors;

namespace RideShareWebAPI.Controllers
{
    public class DriversController : ApiController
    {
        private RideShareDBEntities db = new RideShareDBEntities();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/Drivers
        public IQueryable<Driver> GetDrivers()
        {
            return db.Drivers;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/Drivers/5
        [ResponseType(typeof(Driver))]
        public async Task<IHttpActionResult> GetDriver(int id)
        {
            Driver driver = await db.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // PUT: api/Drivers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDriver(int id, Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driver.DriverId)
            {
                return BadRequest();
            }

            db.Entry(driver).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POST: api/Drivers
        [ResponseType(typeof(Driver))]
        public async Task<IHttpActionResult> PostDriver(Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Drivers.Add(driver);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = driver.DriverId }, driver);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // DELETE: api/Drivers/5
        [ResponseType(typeof(Driver))]
        public async Task<IHttpActionResult> DeleteDriver(int id)
        {
            Driver driver = await db.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            db.Drivers.Remove(driver);
            await db.SaveChangesAsync();

            return Ok(driver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DriverExists(int id)
        {
            return db.Drivers.Count(e => e.DriverId == id) > 0;
        }
    }
}