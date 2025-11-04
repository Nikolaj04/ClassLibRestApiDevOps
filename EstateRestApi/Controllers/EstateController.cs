using Microsoft.AspNetCore.Mvc;
using EstateLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EstateRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private EstateRepo _repo;

        public EstateController(EstateRepo repo)
        {
            _repo = repo;
        }


        // GET: api/<EstateController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Estate>> GetAll()
        {
            List<Estate> estates = _repo.GetAllEstates();

            if (estates.Count == 0) return NoContent();

            return Ok(estates);
        }

        // GET api/<EstateController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Estate> Get(int id)
        {
            Estate? estate = _repo.GetEstateById(id);

            if (estate == null) return NotFound();

            return Ok(estate);
        }

        // POST api/<EstateController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Estate> Post([FromBody] Estate newEstate)
        {
            try
            {
                _repo.AddEstate(newEstate);
                return Created("/" + newEstate.Id, newEstate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<EstateController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Estate> Put(int id, [FromBody] Estate value)
        {
            Estate? updatedEstate = _repo.UpdateEstate(id, value);

            if (updatedEstate == null) return NotFound();

            return Ok(updatedEstate);
        }

        // DELETE api/<EstateController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Estate> Delete(int id)
        {
            Estate? deletedEstate = _repo.DeleteEstate(id);

            if (deletedEstate == null) return NotFound();

            return Ok(deletedEstate);
        }
    }
}
