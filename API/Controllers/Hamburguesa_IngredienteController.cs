using API.Dtos.Hamburguesa_IngredienteDto;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class Hamburguesa_IngredienteController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Hamburguesa_IngredienteController(IUnitOfWork unitOfWork, IMapper mapper) :base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult> Add(Hamburguesa_IngredienteDto Hamburguesa_IngredienteDto)
        {
            if(Hamburguesa_IngredienteDto == null)
                    return BadRequest();

            Hamburguesa_Ingrediente Hamburguesa_Ingrediente = _mapper.Map<Hamburguesa_Ingrediente>(Hamburguesa_IngredienteDto);
            _unitOfWork.Hamburguesa_Ingredientes.Add(Hamburguesa_Ingrediente);  

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            return CreatedAtAction(nameof(Add), new {id = Hamburguesa_Ingrediente.HamburguesaId,Hamburguesa_Ingrediente.IngredienteId },Hamburguesa_Ingrediente);
        }



        [HttpPost("AñadirIngredienteClasica{ingredienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult> AddIngrediente(int ingredienteId)
        {       
            Hamburguesa_Ingrediente h = new Hamburguesa_Ingrediente
            {
                HamburguesaId =10,
                IngredienteId = ingredienteId
            };
            _unitOfWork.Hamburguesa_Ingredientes.Add( h);  
            _unitOfWork.SaveAsync();


             return  CreatedAtAction(nameof(AddIngrediente), new {id = h.HamburguesaId,h.IngredienteId},h);
        }



        [HttpPost("Range")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

            public async Task<ActionResult> AddRange(IEnumerable<Hamburguesa_IngredienteDto> Hamburguesa_IngredientesDto)
        {
            if(Hamburguesa_IngredientesDto == null)
                    return BadRequest();

            IEnumerable<Hamburguesa_Ingrediente> Hamburguesa_Ingredientes = _mapper.Map<IEnumerable<Hamburguesa_Ingrediente>>(Hamburguesa_IngredientesDto);
            _unitOfWork.Hamburguesa_Ingredientes.AddRange(Hamburguesa_Ingredientes);  

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            foreach(var c in Hamburguesa_Ingredientes )
            {
                CreatedAtAction(nameof(AddRange), new {id = c.HamburguesaId,c.IngredienteId},c);
            }

            return Ok();

            
            
        }


        [HttpGet("{HamburgesaId},{IngredienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Hamburguesa_IngredienteDto>> GetById(int HamburgesaId,int IngredienteId)
        {
            Hamburguesa_Ingrediente Hamburguesa_Ingrediente =await  _unitOfWork.Hamburguesa_Ingredientes.GetByIdAsync(HamburgesaId,IngredienteId);

                if(Hamburguesa_Ingrediente == null)
                    return BadRequest();

            return _mapper.Map<Hamburguesa_IngredienteDto>(Hamburguesa_Ingrediente);

        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Hamburguesa_IngredienteDto>>> GetAll()
        {
            IEnumerable<Hamburguesa_Ingrediente> Hamburguesa_Ingrediente =await  _unitOfWork.Hamburguesa_Ingredientes.GetAllAsync();

                if(Hamburguesa_Ingrediente == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<Hamburguesa_IngredienteDto>>(Hamburguesa_Ingrediente));

        }
        

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        
        public async Task<ActionResult> Update(int HamburgesaId,int IngredienteId , [FromBody]Hamburguesa_IngredienteDto Hamburguesa_IngredienteDto)
        {
            if(Hamburguesa_IngredienteDto == null)
                return BadRequest();

            Hamburguesa_Ingrediente Hamburguesa_Ingrediente = await _unitOfWork.Hamburguesa_Ingredientes.GetByIdAsync(HamburgesaId,IngredienteId);
            _unitOfWork.Hamburguesa_Ingredientes.Remove(Hamburguesa_Ingrediente);
            await _unitOfWork.SaveAsync();
            _mapper.Map(Hamburguesa_IngredienteDto, Hamburguesa_Ingrediente);
           
            _unitOfWork.Hamburguesa_Ingredientes.Add(Hamburguesa_Ingrediente);

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            return Ok("REGISTRO ACTUALIZADO CON EXITO");
        }


        [HttpDelete("{HamburguesaId},{IngredienteId}")]  
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        

        public async Task<ActionResult> Delete(int HamburguesaId,int IngredienteId)
        {
            Hamburguesa_Ingrediente Hamburguesa_Ingrediente = await _unitOfWork.Hamburguesa_Ingredientes.GetByIdAsync(HamburguesaId,IngredienteId);

            if(Hamburguesa_Ingrediente == null)
                return BadRequest();

            _unitOfWork.Hamburguesa_Ingredientes.Remove(Hamburguesa_Ingrediente);

            int num = await _unitOfWork.SaveAsync();

            if (num == 0)
                return BadRequest();

            return NoContent();
        }
    }   
}