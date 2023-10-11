using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnimals.Controllers
{
    public class ClienteDireccionController : BaseControllerApi
    {
         private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClienteDireccionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDireccionDto>>> Get()
    {
        var clientD = await _unitOfWork.ClienteDirecciones.GetAllAsync();
        return _mapper.Map<List<ClienteDireccionDto>>(clientD);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDireccionDto>> Get(int id)
    {
        var cliente = await _unitOfWork.ClienteDirecciones.GetByIdAsync(id);
        if(cliente == null)
            return NotFound();
        return _mapper.Map<ClienteDireccionDto>(cliente);
    }   

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDireccion>> Post([FromBody] ClienteDireccionDto clienteDDto)
    {
        var cliente = _mapper.Map<ClienteDireccion>(clienteDDto);
        _unitOfWork.ClienteDirecciones.Add(cliente);
        await _unitOfWork.SaveAsync();
        if(cliente == null)
            return BadRequest();
        clienteDDto.Id = cliente.Id;
        return CreatedAtAction(nameof(Post), new{id = clienteDDto.Id},clienteDDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDireccionDto>> Put(int id, [FromBody] ClienteDireccionDto clienteDDto)
    {
        if(clienteDDto == null)
            return BadRequest();
        if(clienteDDto.Id == 0)
            clienteDDto.Id = id;
        if(clienteDDto.Id != id)
            return NotFound();
        var cliente = _mapper.Map<ClienteDireccion>(clienteDDto);
        _unitOfWork.ClienteDirecciones.Update(cliente);
        await _unitOfWork.SaveAsync();
        return clienteDDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _unitOfWork.ClienteDirecciones.GetByIdAsync(id);
        if(cliente == null)
            return NotFound();
        _unitOfWork.ClienteDirecciones.Remove(cliente);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
}