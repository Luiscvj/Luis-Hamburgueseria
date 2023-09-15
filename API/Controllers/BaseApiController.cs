using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class BaseApiController : ControllerBase
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public BaseApiController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}
