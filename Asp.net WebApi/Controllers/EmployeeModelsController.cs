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
using Asp.net_WebApi.Models;

namespace Asp.net_WebApi.Controllers
{
    public class EmployeeModelsController : ApiController
    {
        private GaneshEntities db = new GaneshEntities();

        // GET: api/EmployeeModels
        public IQueryable<EmployeeModel> GetEmployeeModels()
        {
            return db.EmployeeModels;
        }

        // GET: api/EmployeeModels/5
        [ResponseType(typeof(EmployeeModel))]
        public IHttpActionResult GetEmployeeModel(int id)
        {
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return Ok(employeeModel);
        }

        // PUT: api/EmployeeModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployeeModel(int id, EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeModel.Empid)
            {
                return BadRequest();
            }

            db.Entry(employeeModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeModelExists(id))
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

        // POST: api/EmployeeModels
        [ResponseType(typeof(EmployeeModel))]
        public IHttpActionResult PostEmployeeModel(EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeModels.Add(employeeModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employeeModel.Empid }, employeeModel);
        }

        // DELETE: api/EmployeeModels/5
        [ResponseType(typeof(EmployeeModel))]
        public IHttpActionResult DeleteEmployeeModel(int id)
        {
            EmployeeModel employeeModel = db.EmployeeModels.Find(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            db.EmployeeModels.Remove(employeeModel);
            db.SaveChanges();

            return Ok(employeeModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeModelExists(int id)
        {
            return db.EmployeeModels.Count(e => e.Empid == id) > 0;
        }
    }
}