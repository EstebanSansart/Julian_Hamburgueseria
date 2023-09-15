using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class HamburguesaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public HamburguesaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Categoria>>> Get()
    {
        var categoria = await _unitOfWork.Categorias.GetAllAsync();
        return Ok(categoria);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<HamburguesaDto>> Get()
    {
        var hamburguesas = await _unitOfWork.Hamburguesas.GetAllAsync();
        return _mapper.Map<List<HamburguesaDto>>(hamburguesas);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<HamburguesaDto>>> Get11([FromQuery] Params _params)
    {
        var hamburguesas = await _unitOfWork.Hamburguesas.GetAllAsync();
        var hamburguesasDto = _mapper.Map<List<HamburguesaDto>>(hamburguesas);
        var pager = new Pager<HamburguesaDto>(hamburguesasDto, hamburguesasDto.Count(),_params.PageIndex, _params.PageSize, _params.Search);
        return CreatedAtAction(nameof(Get), pager);
    }
    [HttpGet("vegetariana")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<HamburguesaCompletaDto>> Vegetariana(){
       var records = await _unitOfWork.Hamburguesas.GetAllAsync(x => x.Categoria.Nombre == "Vegetariana");
       return _mapper.Map<List<HamburguesaCompletaDto>>(records);
    }

    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(Area areaPO){
        this._unitOfWork.Areas.Add(areaPO);
        await _unitOfWork.SaveAsync();
        if (areaPO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = areaPO.Id}, areaPO);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Hamburguesa>> Post(HamburguesaDto hamburguesaDto){
        var hamburguesa = _mapper.Map<Hamburguesa>(hamburguesaDto);
        this._unitOfWork.Hamburguesas.Add(hamburguesa);
        await _unitOfWork.SaveAsync();
        if (hamburguesa == null)
        {
            return BadRequest();
        }        
        return CreatedAtAction(nameof(Post),new {id = hamburguesa.Id}, hamburguesaDto);
    }

    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area areaPU){
        if(areaPU == null)
        {
            return NotFound();
        }
        _unitOfWork.Areas.Update(areaPU);
        await _unitOfWork.SaveAsync();
        return areaPU;
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HamburguesaDto>> Put(int id, [FromBody]HamburguesaDto hamburguesaDto){
        if(hamburguesaDto == null)
        {
            return NotFound();
        }
        var hamburguesas = _mapper.Map<Hamburguesa>(hamburguesaDto);
        _unitOfWork.Hamburguesas.Update(hamburguesas);
        await _unitOfWork.SaveAsync();
        return hamburguesaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var categoria = await _unitOfWork.Hamburguesas.GetByIdAsync(id);
        if(categoria == null)
        {
            return NotFound();
        }
        _unitOfWork.Hamburguesas.Remove(categoria);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}