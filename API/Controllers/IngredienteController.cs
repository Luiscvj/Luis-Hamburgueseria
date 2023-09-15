using API.Dtos.IngredienteDto;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class IngredienteController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IngredienteController(IUnitOfWork unitOfWork, IMapper mapper) :base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult> Add(IngredienteDto IngredienteDto)
        {
            if(IngredienteDto == null)
                    return BadRequest();

            Ingrediente Ingrediente = _mapper.Map<Ingrediente>(IngredienteDto);
            _unitOfWork.Ingredientes.Add(Ingrediente);  

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            return CreatedAtAction(nameof(Add), new {id = Ingrediente.Id },Ingrediente);
        }


        [HttpPut("CambioDescripcionPan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult> AddCambio(IngredienteDescripcioDto actualizacion)
        {
           if(actualizacion == null)
                return BadRequest();
            int idIngrediente = _unitOfWork.Ingredientes.ActualizarDescripcionPan();
            Ingrediente Ingrediente = await _unitOfWork.Ingredientes.GetByIdAsync(idIngrediente);

            _mapper.Map(actualizacion, Ingrediente);
            _unitOfWork.Ingredientes.Update(Ingrediente);

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            return Ok("REGISTRO ACTUALIZADO CON EXITO");
              
        }




        [HttpPost("Range")]
       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

            public async Task<ActionResult> AddRange(IEnumerable<IngredienteDto> IngredientesDto)
        {
            if(IngredientesDto == null)
                    return BadRequest();

            IEnumerable<Ingrediente> Ingredientes = _mapper.Map<IEnumerable<Ingrediente>>(IngredientesDto);
            _unitOfWork.Ingredientes.AddRange(Ingredientes);  

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            foreach(var c in Ingredientes )
            {
                CreatedAtAction(nameof(AddRange), new {id = c.Id},c);
            }

            return Ok();

            
            
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IngredienteDto>> GetById(int id)
        {
            Ingrediente Ingrediente =await  _unitOfWork.Ingredientes.GetByIdAsync(id);

                if(Ingrediente == null)
                    return BadRequest();

            return _mapper.Map<IngredienteDto>(Ingrediente);

        }

        
        [HttpGet("MasCaro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IngredienteDto>> GetMasCaro()
        {
            Ingrediente Ingrediente =await  _unitOfWork.Ingredientes.IngredienteMasCaro();

                if(Ingrediente == null)
                    return BadRequest();

            return _mapper.Map<IngredienteDto>(Ingrediente);

        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<IngredienteDto>>> GetAll()
        {
            IEnumerable<Ingrediente> Ingrediente =await  _unitOfWork.Ingredientes.GetAllAsync();

                if(Ingrediente == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<IngredienteDto>>(Ingrediente));

        }


        
        [HttpGet("GetAllIngredientePaginacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pager<IngredienteHamburguesaDto>>> GetIngredientePaginacion([FromQuery] Params ingParams)
        {
            var Ingrediente = await _unitOfWork.Ingredientes.GetAllAsync(ingParams.PageIndex,ingParams.PageSize,ingParams.Search);
            var listIngredientesDto=_mapper.Map<List<IngredienteHamburguesaDto>>(Ingrediente.registros);

            return new Pager<IngredienteHamburguesaDto>(listIngredientesDto, ingParams.Search, Ingrediente.totalRegistros, ingParams.PageIndex, ingParams.PageSize);

        }


        [HttpGet("GetAllRango")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<IngredienteDto>>> GetAllRango()
        {
            IEnumerable<Ingrediente> Ingrediente =await  _unitOfWork.Ingredientes.PrecioRango();

                if(Ingrediente == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<IngredienteDto>>(Ingrediente));

        }


        [HttpGet("GetAllMas400")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<IngredienteDto>>> GetAllMas400()
        {
            IEnumerable<Ingrediente> Ingrediente =await  _unitOfWork.Ingredientes.StockMas400();

                if(Ingrediente == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<IngredienteDto>>(Ingrediente));

        }
        

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        
        public async Task<ActionResult> Update(int id , [FromBody]IngredienteDto IngredienteDto)
        {
            if(IngredienteDto == null)
                return BadRequest();

            Ingrediente Ingrediente = await _unitOfWork.Ingredientes.GetByIdAsync(id);

            _mapper.Map(IngredienteDto, Ingrediente);
            _unitOfWork.Ingredientes.Update(Ingrediente);

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            return Ok("REGISTRO ACTUALIZADO CON EXITO");
        }


        [HttpDelete("{id}")]  
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        

        public async Task<ActionResult> Delete(int id)
        {
            Ingrediente Ingrediente = await _unitOfWork.Ingredientes.GetByIdAsync(id);

            if(Ingrediente == null)
                return BadRequest();

            _unitOfWork.Ingredientes.Remove(Ingrediente);

            int num = await _unitOfWork.SaveAsync();

            if (num == 0)
                return BadRequest();

            return NoContent();
        }
    }   
}