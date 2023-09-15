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
public class CategoriaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<IEnumerable<CategoriaDto>> Get()
    {
        var categorias = await _unitOfWork.Categorias.GetAllAsync();
        return _mapper.Map<List<CategoriaDto>>(categorias);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CategoriaDto>>> Get11([FromQuery] Params _params)
    {
        var categorias = await _unitOfWork.Categorias.GetAllAsync();
        var categoriasDto = _mapper.Map<List<CategoriaDto>>(categorias);
        var pager = new Pager<CategoriaDto>(categoriasDto, categoriasDto.Count(),_params.PageIndex, _params.PageSize, _params.Search);
        return CreatedAtAction(nameof(Get), pager);
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
    public async Task<ActionResult<Categoria>> Post(CategoriaDto categoriaDto){
        var categoria = _mapper.Map<Categoria>(categoriaDto);
        this._unitOfWork.Categorias.Add(categoria);
        await _unitOfWork.SaveAsync();
        if (categoria == null)
        {
            return BadRequest();
        }        
        return CreatedAtAction(nameof(Post),new {id = categoria.Id}, categoriaDto);
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
    public async Task<ActionResult<CategoriaDto>> Put(int id, [FromBody]CategoriaDto categoriaDto){
        if(categoriaDto == null)
        {
            return NotFound();
        }
        var categorias = _mapper.Map<Categoria>(categoriaDto);
        _unitOfWork.Categorias.Update(categorias);
        await _unitOfWork.SaveAsync();
        return categoriaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
        if(categoria == null)
        {
            return NotFound();
        }
        _unitOfWork.Categorias.Remove(categoria);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}