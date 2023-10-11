using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnimals.Controllers
{
    public class ServicioController: BaseControllerApi
    {
         private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ServicioController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ServicioDto>>> Get()
    {
        var servicios = await _unitOfWork.Servicio.GetAllAsync();
        return _mapper.Map<List<ServicioDto>>(servicios);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServicioDto>> Get(int id)
    {
        var servicio = await _unitOfWork.Servicio.GetByIdAsync(id);
        if(servicio == null)
        {
            return NotFound();
        }
        return _mapper.Map<ServicioDto>(servicio);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Servicio>> Post([FromBody] ServicioDto servicioDto)
    {
        var servicio = _mapper.Map<Servicio>(servicioDto);
        _unitOfWork.Servicio.Add(servicio);
        await _unitOfWork.SaveAsync();
        if(servicio == null)
        {
            return BadRequest();
        }
        servicioDto.Id = servicio.Id ;
        return CreatedAtAction(nameof(Post), new{id = servicioDto.Id}, servicioDto);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServicioDto>> Put(int id, [FromBody] ServicioDto servicioDto)
    {
        if(servicioDto == null)
            return BadRequest();
        if(servicioDto.Id == 0)
            servicioDto.Id = id;
        if(servicioDto.Id != id)
            return NotFound();
        var servicio = _mapper.Map<Servicio>(servicioDto);
        _unitOfWork.Servicio.Update(servicio);
        await _unitOfWork.SaveAsync();
        return servicioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var servicio = await _unitOfWork.Servicio.GetByIdAsync(id);
        if(servicio == null)
            return NotFound();
        _unitOfWork.Servicio.Remove(servicio);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
}