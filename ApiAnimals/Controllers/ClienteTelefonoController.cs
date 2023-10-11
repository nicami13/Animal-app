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
    public class ClienteTelefonoController: BaseControllerApi
    {
 private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClienteTelefonoController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteTelefonoDto>>> Get()
    {
        var clienteT = await _unitOfWork.ClienteTelefonos.GetAllAsync();
        return _mapper.Map<List<ClienteTelefonoDto>>(clienteT);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteTelefonoDto>> Get(int id)
    {
        var clit = await _unitOfWork.ClienteTelefonos.GetByIdAsync(id);
        if(clit == null)
        {
            return NotFound();
        }
        return _mapper.Map<ClienteTelefonoDto>(clit);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteTelefono>> Post([FromBody] ClienteTelefonoDto cliTDto)
    {
        var cliente =  _mapper.Map<ClienteTelefono>(cliTDto);
        _unitOfWork.ClienteTelefonos.Add(cliente);
        await _unitOfWork.SaveAsync();
        if(cliente == null)
        {
            return BadRequest();
        }
        cliTDto.Id = cliente.Id;
        return CreatedAtAction(nameof(Post), new {id = cliTDto.Id}, cliTDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteTelefonoDto>> Put(int id, [FromBody] ClienteTelefonoDto clienTDto)
    {
        if(clienTDto == null)
            return BadRequest();
        if(clienTDto.Id == 0)
            clienTDto.Id = id;
        if(clienTDto.Id != id)
            return NotFound();

        var clienT = _mapper.Map<ClienteTelefono>(clienTDto);
        _unitOfWork.ClienteTelefonos.Update(clienT);
        await _unitOfWork.SaveAsync();
        return clienTDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var clienT = await _unitOfWork.ClienteTelefonos.GetByIdAsync(id);
        if(clienT == null)
        {
            return NotFound();
        }
        _unitOfWork.ClienteTelefonos.Remove(clienT);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    }
}