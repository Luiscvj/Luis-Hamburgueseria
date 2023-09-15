using API.Dtos.HamburguesaDto;
using API.Dtos.IngredienteDto;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HamburguesaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HamburguesaController(IUnitOfWork unitOfWork, IMapper mapper) :base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult> Add(HamburguesaDto HamburguesaDto)
        {
            if(HamburguesaDto == null)
                    return BadRequest();

            Hamburguesa Hamburguesa = _mapper.Map<Hamburguesa>(HamburguesaDto);
            _unitOfWork.Hamburguesas.Add(Hamburguesa);  

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            return CreatedAtAction(nameof(Add), new {id = Hamburguesa.Id },Hamburguesa);
        }




        [HttpPost("Range")]   
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

            public async Task<ActionResult> AddRange(IEnumerable<HamburguesaDto> HamburguesasDto)
        {
            if(HamburguesasDto == null)
                    return BadRequest();

            IEnumerable<Hamburguesa> Hamburguesas = _mapper.Map<IEnumerable<Hamburguesa>>(HamburguesasDto);
            _unitOfWork.Hamburguesas.AddRange(Hamburguesas);  

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            foreach(var c in Hamburguesas )
            {
                CreatedAtAction(nameof(AddRange), new {id = c.Id},c);
            }

            return Ok();

            
            
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<HamburguesaDto>> GetById(int id)
        {
            Hamburguesa Hamburguesa =await  _unitOfWork.Hamburguesas.GetByIdAsync(id);

                if(Hamburguesa == null)
                    return BadRequest();

            return Ok(_mapper.Map<HamburguesaDto>(Hamburguesa));

        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<HamburguesaDto>>> GetAll()
        {
            IEnumerable<Hamburguesa> Hamburguesa =await  _unitOfWork.Hamburguesas.GetAllAsync();

                if(Hamburguesa == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<HamburguesaDto>>(Hamburguesa));

        }


          
        [HttpGet("GetAllHamburguesaPaginacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pager<HamburguesaIngredienteDto>>> GetHamburguesaPaginacion([FromQuery] Params hambParams)
        {
            var Hamburguesa = await _unitOfWork.Hamburguesas.GetAllAsync(hambParams.PageIndex,hambParams.PageSize,hambParams.Search);
            var listHamburguesasDto=_mapper.Map<List<HamburguesaIngredienteDto>>(Hamburguesa.registros);

            return new Pager<HamburguesaIngredienteDto>(listHamburguesasDto, hambParams.Search, Hamburguesa.totalRegistros, hambParams.PageIndex, hambParams.PageSize);

        }


        [HttpGet("GetAllHamburguesaBarata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<HamburguesaDto>>> GetAllHamburguesaBarata()
        {
            IEnumerable<Hamburguesa> Hamburguesa =await  _unitOfWork.Hamburguesas.GetHamburgesasPrecioRango();

                if(Hamburguesa == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<HamburguesaDto>>(Hamburguesa));

        }


        [HttpGet("GetAllHamburguesaAscendeingByPrice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<HamburguesaDto>>> GetAllHamburguesaAscending()
        {
            IEnumerable<Hamburguesa> Hamburguesa =await  _unitOfWork.Hamburguesas.GetHamburguesaAscendingByPrice();

                if(Hamburguesa == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<HamburguesaDto>>(Hamburguesa));

        }

        [HttpGet("GetAmburguesaVegetariana")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<HamburguesaDto>>> GetHamburguesaVegetariana()
        {
            IEnumerable<Hamburguesa> Hamburguesa =await  _unitOfWork.Hamburguesas.GetHamburgesasVegetarianas();

                if(Hamburguesa == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<HamburguesaDto>>(Hamburguesa));

        }


        [HttpGet("GetAmburguesaPanIntegral")]
       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<IngredienteHamburguesaDto>>> GetHamburguesaPamIntegral()
        {
            IEnumerable<Ingrediente> Ingrediente =await  _unitOfWork.Hamburguesas.GetHamburgesasPanIntegral();
          
              /*   if(Hamburguesa == null)
                    return BadRequest(); */

            return Ok(_mapper.Map<IEnumerable<IngredienteHamburguesaDto>>(Ingrediente));

        }
        

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        
        public async Task<ActionResult> Update(int id , [FromBody]HamburguesaDto HamburguesaDto)
        {
            if(HamburguesaDto == null)
                return BadRequest();

            Hamburguesa Hamburguesa = await _unitOfWork.Hamburguesas.GetByIdAsync(id);

            _mapper.Map(HamburguesaDto, Hamburguesa);
            _unitOfWork.Hamburguesas.Update(Hamburguesa);

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
            Hamburguesa Hamburguesa = await _unitOfWork.Hamburguesas.GetByIdAsync(id);

            if(Hamburguesa == null)
                return BadRequest();

            _unitOfWork.Hamburguesas.Remove(Hamburguesa);

            int num = await _unitOfWork.SaveAsync();

            if (num == 0)
                return BadRequest();

            return NoContent();
        }
    }   
}