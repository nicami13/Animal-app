using System.Collections.Generic;
using System.Threading.Tasks;
using ApiAnimals.Controllers;
using ApiAnimals.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PaisController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
        {
            var paises = await _unitOfWork.Paises.GetAllAsync();
            return Ok(_mapper.Map<List<PaisDto>>(paises));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            var pais = await _unitOfWork.Paises.GetByIdAsync(id);
            if (pais == null)
                return NotFound();

            return Ok(_mapper.Map<PaisDto>(pais));
        }

        [HttpPost]
        public async Task<ActionResult<PaisDto>> Post([FromBody] PaisDto paisDto)
        {
            if (paisDto == null)
                return BadRequest();

            var pais = _mapper.Map<Pais>(paisDto);
            _unitOfWork.Paises.Add(pais);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = pais.Id }, _mapper.Map<PaisDto>(pais));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PaisDto>> Put(int id, [FromBody] PaisDto paisDto)
        {
            if (paisDto == null || id != paisDto.Id)
                return BadRequest();

            var paisExistente = await _unitOfWork.Paises.GetByIdAsync(id);
            if (paisExistente == null)
                return NotFound();

            _mapper.Map(paisDto, paisExistente);
            _unitOfWork.Paises.Update(paisExistente);
            await _unitOfWork.SaveAsync();

            return Ok(_mapper.Map<PaisDto>(paisExistente));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var pais = await _unitOfWork.Paises.GetByIdAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            _unitOfWork.Paises.Remove(pais);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
