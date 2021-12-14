using DataMergeEditor_Restfull_API.Models.EntityModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataMergeEditor_Restfull_API.Controllers.User
{
    [Route("dme/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersContextModel db;
        public UsersController(UsersContextModel contextmodel)
        {
            this.db = contextmodel;
        }

        // GET: api/<UsersController>
        // https://localhost:44320/dme/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Get's the list of users
            var dbResponseData = db?.Users;

            // null check
            if (dbResponseData == null)
                return NotFound();

            // checks if any data exists
            if(await dbResponseData?.AnyAsync())
                return Ok(dbResponseData);
            else
                return NotFound();

        }

        // GET api/<UsersController>/5
        // https://localhost:44320/dme/Users/2
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // Fetches the data
            Users dbResponseData = await db?.Users?.FirstOrDefaultAsync(user => user.UserID == id);

            // null check
            if (dbResponseData == null)
                return NotFound();
            else
                return Ok(dbResponseData);
        }

        // POST api/<UsersController>
        // https://localhost:44320/dme/Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Users value)
        {
            // null check
            if (value != null || db != null)
            {
                // Set's state
                db.Entry(value).State = EntityState.Added;

                // adding the user
                await db.AddAsync(value);

                // saves the changes 
                await db.SaveChangesAsync();

                return Ok(db.Entry(value).State);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Get's the user
            var dataResult = await db?.Users?.FirstOrDefaultAsync(user => user.UserID == id);

            // null check
            if (dataResult != null)
            {
                // set's entity state
                db.Entry(dataResult).State = EntityState.Deleted;

                // removes it
                db?.Remove(dataResult);

                // save changes 
                await db.SaveChangesAsync();

                // returns state
                return Ok(db.Entry(dataResult).State);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
