using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUdes.Controllers;
using ApiUdes.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUdes.controllers;

public class UserController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        /* return Ok(users); */
        return _mapper.Map<List<UserDto>>(users);
    }

    /*     [HttpPost("GetUserByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(LoginDto model)
        {
            var us = _mapper.Map<User>(model);
            var user = await _unitOfWork.Users.GetUserByName(us);
            return Ok(user);
        } */

    [HttpPost("GetUserByName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(LoginDto model)
    {
        var us = _mapper.Map<Login>(model);
        var user = await _unitOfWork.Users.GetUserByName(us);
        if (user == null)
        {
            var respJson = new Dictionary<string, string>()
            {
                {"resp","The user does not exist"}
            };
            return Ok(respJson);
        }
        return Ok(user);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDto>> Get(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        /* return Ok(user); */
        return _mapper.Map<UserDto>(user);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> Post(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);

        this._unitOfWork.Users.Add(user);
        await _unitOfWork.SaveAsync();
        if (user == null)
        {
            return BadRequest();
        }
        user.IdUser = userDto.IdUser;
        return CreatedAtAction(nameof(Post), new { id = userDto.IdUser }, userDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserDto>> Put(int id, [FromBody] UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        if (user.IdUser == 0)
        {
            user.IdUser = id;
        }
        if (user.IdUser != id)
        {
            return BadRequest();
        }
        if (user == null)
        {
            return NotFound();
        }

        userDto.IdUser = user.IdUser;
        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveAsync();
        return userDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        _unitOfWork.Users.Remove(user);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}