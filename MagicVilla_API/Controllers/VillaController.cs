using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {

        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;

        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;   
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Obtener las villas");
            return Ok(_db.Villas.ToList());
        }


        [HttpGet("id:int", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer villa con el ID " + id);
                return BadRequest();
            }


            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);

            if (villa == null) return NotFound();

            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_db.Villas.FirstOrDefault(v => v.Name.ToLower() == villaDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("NameExists", "The village with that Name already exist!");
                return BadRequest(ModelState);
            }

            if (villaDto == null) return BadRequest();

            if (villaDto.Id > 0) return StatusCode(StatusCodes.Status500InternalServerError);

            Villa model = new()
            {
                
                Name = villaDto.Name,
                Details = villaDto.Details,
                ImageUrl = villaDto.ImageUrl,
                Occupants = villaDto.Occupants,
                Fee = villaDto.Fee,
                MetersSquared = villaDto.MetersSquared, 
                Amenity = villaDto.Amenity,
            };

            _db.Villas.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new { id = villaDto.Id }, villaDto);
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]    
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0) return BadRequest();

            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);
            if (villa == null) return NotFound();

            _db.Villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {

            if (villaDto == null) return BadRequest();

            Villa model = new()
            {
                Id = id,
                Name = villaDto.Name,
                Details = villaDto.Details,
                ImageUrl = villaDto.ImageUrl,
                Occupants = villaDto.Occupants,
                Fee = villaDto.Fee,
                MetersSquared = villaDto.MetersSquared,
                Amenity = villaDto.Amenity,
            };

            _db.Villas.Update(model);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {

            if (patchDto == null || id == 0) return BadRequest();

            var villa = _db.Villas.AsNoTracking().FirstOrDefault(v => v.Id == id);

            VillaDto villaDto = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                ImageUrl = villa.ImageUrl,
                Occupants = villa.Occupants,
                Fee = villa.Fee,
                MetersSquared = villa.MetersSquared,
                Amenity = villa.Amenity,

            };

            if(villa == null) return BadRequest();

            patchDto.ApplyTo(villaDto, ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            Villa model = new()
            {
                Id = villaDto.Id,
                Name = villaDto.Name,
                Details = villaDto.Details,
                ImageUrl = villaDto.ImageUrl,
                Occupants = villaDto.Occupants,
                Fee = villaDto.Fee,
                MetersSquared = villaDto.MetersSquared,
                Amenity = villaDto.Amenity,

            };

           _db.Villas.Update(model);
           _db.SaveChanges();

            return NoContent();
        }

    }
}
