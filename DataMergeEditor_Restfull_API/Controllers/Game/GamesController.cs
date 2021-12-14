using DataMergeEditor_Restfull_API.Models.EntityModels.Game;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataMergeEditor_Restfull_API.Controllers.Game
{
    [Route("dme/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private GamesContextModel db;
        public GamesController(GamesContextModel contextModel)
        {
            this.db = contextModel;
        }

        // GET: api/<GamesController>
        // https://localhost:44320/dme/Games
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dataresult = db.Games;

            // null check
            if (dataresult == null)
                return NotFound();

            // checks if we have anything before returning an list 
            if(await db.Games?.AnyAsync())
                return Ok(dataresult);
            else
                return NotFound();
        }

        // GET api/<GamesController>/5
        // https://localhost:44320/dme/2
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // finds the game based on id
            var dataResult = await db.Games?.FirstOrDefaultAsync(game => game.GameID == id);
            
            // null check
            if(dataResult != null)
            {
                return Ok(dataResult);
            }
            else
            {
                return NotFound();
            }
        }
  

        // POST api/<GamesController>
        // https://localhost:44320/dme/Games
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Games value)
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

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Get's the game
            var dataResult = await db?.Games?.FirstOrDefaultAsync(game => game.GameID == id);

            // null check
            if(dataResult != null)
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


