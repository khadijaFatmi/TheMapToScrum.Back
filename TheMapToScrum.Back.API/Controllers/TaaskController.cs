using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.BLL.Interfaces;
using System;
using Microsoft.AspNetCore.Cors;
using TheMapToScrum.Back.Common.Logging;

namespace TheMapToScrum.Back.API.Controllers
{

  //[Authorize]    
  [Produces("application/json")]
  [EnableCors("CorsPolicy")]
  [Route("api/[controller]")]
  public class TaaskController : Controller
  {
    //injection dep
    private readonly ITaaskLogic _logic;
    private readonly ILoggingService loggingService = null;
    private readonly LogItem logItem = new LogItem();

    public TaaskController(ITaaskLogic logic, ILoggingService LoggingService)
    {
      _logic = logic;
      loggingService = LoggingService;
      logItem.NomApplication = "TheMaptoScrum";
      logItem.Layer = "IHM";
      logItem.Location = "TaaskController";
    }

    // Statuscode 500 = erreur serveur
    // les exceptions seront loggees
    [HttpGet("{id}")]
    public ActionResult<TaaskDTO> GetById(int id)
    {
      try
      {
        TaaskDTO retour = new TaaskDTO();
        retour = _logic.GetById(id);
        if (retour.Id == null)
        {
          return StatusCode(404, "Id not found");
        }
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

    [HttpGet]
    [Produces(typeof(TaaskDTO))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<List<TaaskDTO>> Get()
    {
      try
      {
        List<TaaskDTO> retour = new List<TaaskDTO>();
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

    [HttpGet("listeByUsId/{id}")]
    public ActionResult<List<TaaskDTO>> GetByUsId(int id)
    {
      try
      {
        List<TaaskDTO> retour = new List<TaaskDTO>();
        retour = _logic.ListeByUsId(id);
        return retour;
      }
      catch (Exception ex)
      {
        logItem.Exception = ex;       
        logItem.MethodName = "GetByusid";
        loggingService.WriteError(logItem);
        return StatusCode(500, ex);
      }
    }

    [HttpGet("listeByProjectId/{id}")]
    public ActionResult<List<TaaskDTO>> GetByProjectId(int id)
    {
      try
      {
        List<TaaskDTO> retour = new List<TaaskDTO>();
        retour = _logic.ListeByProjectId(id);
        return retour;
      }
      catch (Exception ex)
      {
        logItem.Exception = ex;    
        logItem.MethodName = "GetbyprojectId";
        loggingService.WriteError(logItem);
        return StatusCode(500, ex);
      }
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    
    public ActionResult<TaaskDTO> Post([FromBody] TaaskDTO objet)
    {
      if (ModelState.IsValid)
      {
        try
        {
          TaaskDTO resultat = _logic.Create(objet);
          return resultat;
        }
        catch (Exception ex)
        {
          logItem.Exception = ex;         
          logItem.MethodName = "post";
          loggingService.WriteError(logItem);
          return StatusCode(500, ex);
        }
      }
      else
      {
        return BadRequest("Invalid TaaskDTO Model: failed to POST ");
      }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    //modification d'entité avec fourniture de l'Id obligatoire
    public ActionResult<TaaskDTO> Put([FromBody] TaaskDTO objet)
    {
      if (ModelState.IsValid && objet.Id.HasValue)
      {
        try
        {
          TaaskDTO resultat = _logic.Update(objet);
          return resultat;
        }
        catch (Exception ex)
        {
          logItem.Exception = ex;         
          logItem.MethodName = "put";
          loggingService.WriteError(logItem);
          return StatusCode(500, ex);
        }
      }
      else
      {
        return BadRequest("Invalid TaaskDTO Model & Id Value: failed to PUT");
      }
    }

    //id in url
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
         
          logItem.MethodName = "delete";
          loggingService.WriteError(logItem);
          return StatusCode(500, ex);
        }
      }
      else
      {
        return BadRequest("Invalid TaaskDTO Id Value: failed to DELETE");
      }
    }


  }
}
