using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.Common.Logging;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.Controllers
{
  //[Authorize]    
  [Produces("application/json")]
  [EnableCors("CorsPolicy")]
  [Route("api/[controller]")]
  public class ScrumMasterController : Controller
  {
    private readonly IScrumMasterLogic _logic;
    private readonly ILoggingService loggingService = null;
    private readonly LogItem logItem = new LogItem();

    public ScrumMasterController(IScrumMasterLogic logic, ILoggingService LoggingService)
    {
      _logic = logic;
      loggingService = LoggingService;
      logItem.NomApplication = "TheMaptoScrum";
      logItem.Location = "SMController";
      logItem.Layer = "IHM";
    }


    // Statuscode 500 = erreur serveur
    // les exceptions seront loggees
    [HttpGet]
    [Produces(typeof(List<ScrumMasterDTO>))]
    public ActionResult<List<ScrumMasterDTO>> Get()
    {
      try
      {
        List<ScrumMasterDTO> retour = new List<ScrumMasterDTO>();
        retour = _logic.ListActive();
        return retour;
      }
      catch (Exception ex)
      {
        logItem.Exception = ex;
        logItem.MethodName = "Get";

        loggingService.WriteError(logItem);
        return StatusCode(500, ex);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<ScrumMasterDTO> GetById(int id)
    {
      try
      {
        ScrumMasterDTO retour = new ScrumMasterDTO();
        retour = _logic.GetById(id);
        return retour;
      }
      catch (Exception ex)
      {
        logItem.Exception = ex;
        logItem.MethodName = "GetById";
        loggingService.WriteError(logItem);
        return StatusCode(500, ex);
      }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<ScrumMasterDTO> Post([FromBody] ScrumMasterDTO objet)
    {
      if (ModelState.IsValid)
      {
        try
        {
          ScrumMasterDTO resultat = _logic.Create(objet);
          return resultat;
        }
        catch (Exception ex)
        {
          logItem.Exception = ex;
          logItem.MethodName = "Post";
          loggingService.WriteError(logItem);
          return StatusCode(500, ex);
        }
      }
      else
      {
        return BadRequest("Invalid ScrumMasterDTO ModelState: failed to POST");
      }
    }

    //modification d'entité avec fourniture de l'Id obligatoire
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]

    public ActionResult<ScrumMasterDTO> Put([FromBody] ScrumMasterDTO objet)
    {
      if (ModelState.IsValid && objet.Id.HasValue)
      {
        try
        {
          ScrumMasterDTO resultat = _logic.Update(objet);
          return resultat;
        }
        catch (Exception ex)
        {
          logItem.Exception = ex;
          logItem.MethodName = "Put";
          loggingService.WriteError(logItem);
          return StatusCode(500, ex);
        }
      }
      else
      {
        return BadRequest("Invalid ScrumMasterDTO ModelState: failed to PUT");
      }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public ActionResult<bool> Delete(int? Id)
    {
      if (Id.HasValue)
      {
        try
        {
          bool resultat = _logic.Delete((int)Id);
          return resultat;
        }
        catch (Exception ex)
        {
          logItem.Exception = ex;
          logItem.MethodName = "Delete";
          loggingService.WriteError(logItem);
          return StatusCode(500, ex);
        }
      }
      else
      {
        return BadRequest("Invalid ScrumMasterDTO ModelState: failed to DELETE");
      }
    }
  }
}
