using System;
using System.Collections.Generic;
using System.Security.Claims;
using honey_harvest.Models;
using honey_harvest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace honey_harvest.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    public ProfilesController(ProfilesService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Profile>> Get()
    {
      try
      {

        return Ok(_ps.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Profile> GetById(int id)
    {
      try
      {
        string email = "";
        var claim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (claim != null)
        {
          email = claim.Value;
        }
        return Ok(_ps.Get(id, email));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public ActionResult<Profile> Post([FromBody] Profile newProfile)
    {
      try
      {
        var email = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newProfile.Email = email;
        return Ok(_ps.Create(newProfile));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Profile> Edit(int id, [FromBody] Profile profileToUpdate)
    {
      try
      {
        string email = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        profileToUpdate.Email = email;
        profileToUpdate.Id = id;
        return Ok(_ps.Edit(profileToUpdate));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        string email = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ps.Delete(id, email));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
        throw;
      }
    }
  }
}