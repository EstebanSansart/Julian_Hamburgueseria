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
public class IngredienteController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public IngredienteController(IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<IEnumerable<IngredienteDto>> Get()
    {
        var ingredientes = await _unitOfWork.Ingredientes.GetAllAsync();
        return _mapper.Map<List<IngredienteDto>>(ingredientes);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<IngredienteDto>>> Get11([FromQuery] Params _params)
    {
        var ingredientes = await _unitOfWork.Ingredientes.GetAllAsync();
        var ingredientesDto = _mapper.Map<List<IngredienteDto>>(ingredientes);
        var pager = new Pager<IngredienteDto>(ingredientesDto, ingredientesDto.Count(),_params.PageIndex, _params.PageSize, _params.Search);
        return CreatedAtAction(nameof(Get), pager);
    }
    [HttpGet("StockMin")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<IngredienteDto>> StockMin()
    {
        var ingredientes = await _unitOfWork.Ingredientes.GetAllAsync(a => a.Stock < 400);
        return _mapper.Map<List<IngredienteDto>>(ingredientes);
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
    public async Task<ActionResult<Ingrediente>> Post(IngredienteDto ingredienteDto){
        var ingrediente = _mapper.Map<Ingrediente>(ingredienteDto);
        this._unitOfWork.Ingredientes.Add(ingrediente);
        await _unitOfWork.SaveAsync();
        if (ingrediente == null)
        {
            return BadRequest();
        }        
        return CreatedAtAction(nameof(Post),new {id = ingrediente.Id}, ingredienteDto);
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
    public async Task<ActionResult<IngredienteDto>> Put(int id, [FromBody]IngredienteDto ingredienteDto){
        if(ingredienteDto == null)
        {
            return NotFound();
        }
        var ingredientes = _mapper.Map<Ingrediente>(ingredienteDto);
        _unitOfWork.Ingredientes.Update(ingredientes);
        await _unitOfWork.SaveAsync();
        return ingredienteDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var ingrediente = await _unitOfWork.Ingredientes.GetByIdAsync(id);
        if(ingrediente == null)
        {
            return NotFound();
        }
        _unitOfWork.Ingredientes.Remove(ingrediente);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}