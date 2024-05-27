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

public class RolController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RoleDto>>> Get()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();
        /* return Ok(roles); */
        return _mapper.Map<List<RoleDto>>(roles);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RoleDto>> Get(int id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        /* return Ok(rol); */
        return _mapper.Map<RoleDto>(rol);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Role>> Post(RoleDto roleDto)
    {
        var rol = _mapper.Map<Role>(roleDto);

        this._unitOfWork.Roles.Add(rol);
        await _unitOfWork.SaveAsync();
        if (rol == null)
        {
            return BadRequest();
        }
        roleDto.IdRol = rol.IdRol;
        return CreatedAtAction(nameof(Post), new { id = roleDto.IdRol }, roleDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RoleDto>> Put(int id, [FromBody] RoleDto roleDto)
    {
        var rol = _mapper.Map<Role>(roleDto);
        if (rol.IdRol == 0)
        {
            rol.IdRol = id;
        }
        if (rol.IdRol != id)
        {
            return BadRequest();
        }
        if (rol == null)
        {
            return NotFound();
        }

        roleDto.IdRol = rol.IdRol;
        _unitOfWork.Roles.Update(rol);
        await _unitOfWork.SaveAsync();
        return roleDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        _unitOfWork.Roles.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}



