using API.Dtos.ChefDto;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ChefController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChefController(IUnitOfWork unitOfWork, IMapper mapper) :base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult> Add(ChefDto ChefDto)
        {
            if(ChefDto == null)
                    return BadRequest();

            Chef Chef = _mapper.Map<Chef>(ChefDto);
            _unitOfWork.Chefs.Add(Chef);  

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            return CreatedAtAction(nameof(Add), new {id = Chef.Id },Chef);
        }




        [HttpPost("Range")]
       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

            public async Task<ActionResult> AddRange(IEnumerable<ChefDto> ChefsDto)
        {
            if(ChefsDto == null)
                    return BadRequest();

            IEnumerable<Chef> Chefs = _mapper.Map<IEnumerable<Chef>>(ChefsDto);
            _unitOfWork.Chefs.AddRange(Chefs);  

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            foreach(var c in Chefs )
            {
                CreatedAtAction(nameof(AddRange), new {id = c.Id},c);
            }

            return Ok();

            
            
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ChefDto>> GetById(int id)
        {
            Chef Chef =await  _unitOfWork.Chefs.GetByIdAsync(id);

                if(Chef == null)
                    return BadRequest();

            return _mapper.Map<ChefDto>(Chef);

        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ChefDto>>> GetAll()
        {
            IEnumerable<Chef> Chef =await  _unitOfWork.Chefs.GetAllAsync();

                if(Chef == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<ChefDto>>(Chef));

        }

        [HttpGet("GetAllChefCarnes")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ChefDto>>> GetChefDeCarnes()
        {
            IEnumerable<Chef> Chef =await  _unitOfWork.Chefs.GetChefDeCarnes();

                if(Chef == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<ChefDto>>(Chef));

        }


        [HttpGet("GetAllChefPaginacion")]      
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pager<ChefHamburguesaDto>>> GetChefPaginacion([FromQuery] Params chefParmas)
        {
            var chef = await _unitOfWork.Chefs.GetAllAsync(chefParmas.PageIndex,chefParmas.PageSize,chefParmas.Search);
            var listChefsDto =_mapper.Map<List<ChefHamburguesaDto>>(chef.registros);

            return new Pager<ChefHamburguesaDto>(listChefsDto, chefParmas.Search, chef.totalRegistros, chefParmas.PageIndex, chefParmas.PageSize);

        }


        [HttpGet("GetAllChefHamburguesas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ChefHamburguesaDto>>> GetChefHamburguesas(string Nombre)
        {
            IEnumerable<Chef> Chef =await  _unitOfWork.Chefs.GetHamburguesasEchasPorChef(Nombre);

                if(Chef == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<ChefHamburguesaDto>>(Chef));

        }
        

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        
        public async Task<ActionResult> Update(int id , [FromBody]ChefDto ChefDto)
        {
            if(ChefDto == null)
                return BadRequest();

            Chef Chef = await _unitOfWork.Chefs.GetByIdAsync(id);

            _mapper.Map(ChefDto, Chef);
            _unitOfWork.Chefs.Update(Chef);

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
            Chef Chef = await _unitOfWork.Chefs.GetByIdAsync(id);

            if(Chef == null)
                return BadRequest();

            _unitOfWork.Chefs.Remove(Chef);

            int num = await _unitOfWork.SaveAsync();

            if (num == 0)
                return BadRequest();

            return NoContent();
        }
    }   
}