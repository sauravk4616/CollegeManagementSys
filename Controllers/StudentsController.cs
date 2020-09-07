using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repository;

namespace CollegeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ClgManagementContext _context;
        readonly log4net.ILog _log4net;
        IStudentRep db;

        public StudentsController(StudentRep _db)
        {
            db = _db;

            _log4net = log4net.LogManager.GetLogger(typeof(StudentsController));

        }

        // GET: api/Student
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info("StudentController GET ALL Action Method called");
            try
            {
                var obj = db.GetDetails();
                if (obj == null)
                    return NotFound();
                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public IActionResult Get1(string id)
        {
            Student data = new Student();
            try
            {
                data = db.GetDetail(id);
                if (data == null)
                {
                    return BadRequest(data);
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest(data);
            }
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Post([FromBody] Student obj)
        {
            if (ModelState.IsValid)
            {
               
                try
                {
                    var res = db.AddDetail(obj);
                    if (res != 0)
                        return Ok(res);

                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Student emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = db.UpdateDetail(id, emp);
                    if (result != 1)
                        return NotFound();

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = db.Delete(id);
                if (result == 0)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(id);
            }
        }

    }
}