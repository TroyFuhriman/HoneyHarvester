using System;
using System.Collections.Generic;
using honey_harvest.Models;
using honey_harvest.Services;
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
      catch (Exception e);
      {

        return BadRequest(e.Message);
      };
      }

      [HttpGet("{id}")]
      public ActionResult<Profile> GetById(int id)
      {

      }


    }
  }