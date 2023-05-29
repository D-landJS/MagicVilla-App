using AutoMapper;
using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using MagicVilla_API.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {

        private readonly ILogger<VillaNumberController> _logger;
        private readonly IVillaRepository _villaRepo;
        private readonly IVillaNumberRepository _numberRepo;
        private readonly IMapper _mapper;
        protected APIResponse _apiResponse;

        public VillaNumberController(ILogger<VillaNumberController> logger, IVillaRepository villaRepo, 
                                                                            IVillaNumberRepository numberRepo ,IMapper mapper)
        {
            _logger = logger;
            _villaRepo = villaRepo;
            _numberRepo = numberRepo;
            _mapper = mapper;
            _apiResponse = new();
            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillasNumber()
        {
            try
            {
                _logger.LogInformation("Obtener numeros de villas");

                IEnumerable<VillaNumber> villaNumberList = await _numberRepo.GetAll();

                _apiResponse.Result = _mapper.Map<IEnumerable<VillaNumberDto>>(villaNumberList);
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.isSuccessfull = false;
                _apiResponse.ErrorMessages = new List<string> { ex.ToString() };   
            }
            return _apiResponse;
        }


        [HttpGet("id:int", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Error al traer villa con el ID " + id);
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    _apiResponse.isSuccessfull = false;
                    return BadRequest(_apiResponse);
                }


                var villaNumber = await _numberRepo.Get(v => v.VillaNo == id);

                if (villaNumber == null)
                {
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                    _apiResponse.isSuccessfull = false;
                    return NotFound(_apiResponse);
                }
                _apiResponse.Result = _mapper.Map<VillaNumberDto>(villaNumber);
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.isSuccessfull = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                if (await _numberRepo.Get(v => v.VillaNo == createDto.VillaNo) != null)
                {
                    ModelState.AddModelError("VillaNoExists", "The village with that number already exist!");
                    return BadRequest(ModelState);
                }
                
                if(await _villaRepo.Get(v=> v.Id == createDto.VillaId) == null)
                {
                    ModelState.AddModelError("ForeingKey", "The Villa Id no exists!");
                    return BadRequest(ModelState);
                }

                if (createDto == null) return BadRequest(createDto);


                VillaNumber model = _mapper.Map<VillaNumber>(createDto);

                model.DateCreate = DateTime.Now;
                model.UpdateDate = DateTime.Now;

                await _numberRepo.Create(model);

                _apiResponse.Result = model;
                _apiResponse.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVillaNumber", new { id = model.VillaNo }, _apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.isSuccessfull = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]    
        public async Task<IActionResult> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiResponse.isSuccessfull = false;
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                var villa = await _numberRepo.Get(v => v.VillaNo == id);

                if (villa == null) 
                {
                    _apiResponse.isSuccessfull = false;
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_apiResponse);
                }

                await _numberRepo.Remove(villa);

                _apiResponse.StatusCode = HttpStatusCode.NoContent;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.isSuccessfull = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return BadRequest(_apiResponse);
        }

        [HttpPut("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaNumberUpdateDto udpateDto)
        {

            try
            {
                if (udpateDto == null)
                {
                    _apiResponse.isSuccessfull = false;
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                if(await _villaRepo.Get(v => v.Id == udpateDto.VillaId) == null)
                {
                    ModelState.AddModelError("ForeingKey", "The Villa Id no exists!");
                    return BadRequest(ModelState);
                }

                
                VillaNumber model = _mapper.Map<VillaNumber>(udpateDto);
                model.VillaNo = id;

                await _numberRepo.Update(model);

                _apiResponse.StatusCode = HttpStatusCode.NoContent;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.isSuccessfull = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return BadRequest(_apiResponse);
        }

   

    }
} 
