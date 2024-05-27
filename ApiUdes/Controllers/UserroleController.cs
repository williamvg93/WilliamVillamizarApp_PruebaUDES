using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUdes.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUdes.Controllers;

public class UserroleController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserroleController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UserroleDto>>> Get()
    {
        var userRoles = await _unitOfWork.Userroles.GetAllAsync();
        /* return Ok(userRoles); */
        return _mapper.Map<List<UserroleDto>>(userRoles);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserroleDto>> Get(int id)
    {
        var userRol = await _unitOfWork.Userroles.GetByIdAsync(id);
        if (userRol == null)
        {
            return NotFound();
        }
        /* return Ok(userRol); */
        return _mapper.Map<UserroleDto>(userRol);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Userrole>> Post(UserroleDto userroleDto)
    {
        var userRol = _mapper.Map<Userrole>(userroleDto);

        this._unitOfWork.Userroles.Add(userRol);
        await _unitOfWork.SaveAsync();
        if (userRol == null)
        {
            return BadRequest();
        }
        userroleDto.IdUserRol = userRol.IdUserRol;
        return CreatedAtAction(nameof(Post), new { id = userroleDto.IdUserRol }, userroleDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserroleDto>> Put(int id, [FromBody] UserroleDto userroleDto)
    {
        var userRol = _mapper.Map<Userrole>(userroleDto);
        if (userRol.IdUserRol == 0)
        {
            userRol.IdUserRol = id;
        }
        if (userRol.IdUserRol != id)
        {
            return BadRequest();
        }
        if (userRol == null)
        {
            return NotFound();
        }

        userroleDto.IdUserRol = userRol.IdUserRol;
        _unitOfWork.Userroles.Update(userRol);
        await _unitOfWork.SaveAsync();
        return userroleDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var userRol = await _unitOfWork.Userroles.GetByIdAsync(id);
        if (userRol == null)
        {
            return NotFound();
        }
        _unitOfWork.Userroles.Remove(userRol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}