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
public class ChefController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChefController(IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<IEnumerable<ChefDto>> Get()
    {
        var chefs = await _unitOfWork.Chefs.GetAllAsync();
        return _mapper.Map<List<ChefDto>>(chefs);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ChefDto>>> Get11([FromQuery] Params _params)
    {
        var chefs = await _unitOfWork.Chefs.GetAllAsync();
        var chefsDto = _mapper.Map<List<ChefDto>>(chefs);
        var pager = new Pager<ChefDto>(chefsDto, chefsDto.Count(),_params.PageIndex, _params.PageSize, _params.Search);
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
    public async Task<ActionResult<Chef>> Post(ChefDto chefDto){
        var chef = _mapper.Map<Chef>(chefDto);
        this._unitOfWork.Chefs.Add(chef);
        await _unitOfWork.SaveAsync();
        if (chef == null)
        {
            return BadRequest();
        }        
        return CreatedAtAction(nameof(Post),new {id = chef.Id}, chefDto);
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
    public async Task<ActionResult<ChefDto>> Put(int id, [FromBody]ChefDto chefDto){
        if(chefDto == null)
        {
            return NotFound();
        }
        var chefs = _mapper.Map<Chef>(chefDto);
        _unitOfWork.Chefs.Update(chefs);
        await _unitOfWork.SaveAsync();
        return chefDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var chef = await _unitOfWork.Chefs.GetByIdAsync(id);
        if(chef == null)
        {
            return NotFound();
        }
        _unitOfWork.Chefs.Remove(chef);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}