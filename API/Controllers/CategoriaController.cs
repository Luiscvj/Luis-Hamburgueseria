using API.Dtos.CategoriaDto;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper) :base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult> Add(CategoriaDto categoriaDto)
        {
            if(categoriaDto == null)
                    return BadRequest();

            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _unitOfWork.Categorias.Add(categoria);  

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            return CreatedAtAction(nameof(Add), new {id = categoria.Id },categoria);
        }




        [HttpPost("Range")]       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

            public async Task<ActionResult> AddRange(IEnumerable<CategoriaDto> categoriasDto)
        {
            if(categoriasDto == null)
                    return BadRequest();

            IEnumerable<Categoria> categorias = _mapper.Map<IEnumerable<Categoria>>(categoriasDto);
            _unitOfWork.Categorias.AddRange(categorias);  

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            foreach(var c in categorias )
            {
                CreatedAtAction(nameof(AddRange), new {id = c.Id},c);
            }

            return Ok();

            
            
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<CategoriaDto>> GetById(int id)
        {
            Categoria categoria =await  _unitOfWork.Categorias.GetByIdAsync(id);

                if(categoria == null)
                    return BadRequest();

            return _mapper.Map<CategoriaDto>(categoria);

        }
        

        [HttpGet("CategoriaGourmet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategoriaGourmet()
        {
            IEnumerable<Categoria> categoria =await  _unitOfWork.Categorias.GetGourmetDescripcion();

                if(categoria == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<CategoriaDto>>(categoria));

        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetAll()
        {
            IEnumerable<Categoria> categoria =await  _unitOfWork.Categorias.GetAllAsync();

                if(categoria == null)
                    return BadRequest();

            return Ok(_mapper.Map<IEnumerable<CategoriaDto>>(categoria));

        }


        [HttpGet("GetAllCategoriaPaginacion")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pager<CategoriaHamburguesaDto>>> GetCategoriaPaginacion([FromQuery] Params catParams)
        {
            var Categoria = await _unitOfWork.Categorias.GetAllAsync(catParams.PageIndex,catParams.PageSize,catParams.Search);
            var listCategoriasDto=_mapper.Map<List<CategoriaHamburguesaDto>>(Categoria.registros);

            return new Pager<CategoriaHamburguesaDto>(listCategoriasDto, catParams.Search, Categoria.totalRegistros, catParams.PageIndex, catParams.PageSize);

        }
        

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        
        public async Task<ActionResult> Update(int id , [FromBody]CategoriaDto categoriaDto)
        {
            if(categoriaDto == null)
                return BadRequest();

            Categoria categoria = await _unitOfWork.Categorias.GetByIdAsync(id);

            _mapper.Map(categoriaDto, categoria);
            _unitOfWork.Categorias.Update(categoria);

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
            Categoria categoria = await _unitOfWork.Categorias.GetByIdAsync(id);

            if(categoria == null)
                return BadRequest();

            _unitOfWork.Categorias.Remove(categoria);

            int num = await _unitOfWork.SaveAsync();

            if (num == 0)
                return BadRequest();

            return NoContent();
        }
    }   
}