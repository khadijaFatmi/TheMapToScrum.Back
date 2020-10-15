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
  public class ProductOwnerController : Controller
  {
    //injections dependances
    private readonly IProductOwnerLogic _logic;
    private readonly ILoggingService loggingService = null;
    private readonly LogItem logItem = new LogItem();

    public ProductOwnerController(IProductOwnerLogic logic, ILoggingService LoggingService)
    {
      _logic = logic;
      loggingService = LoggingService;
      logItem.NomApplication = "TheMaptoScrum";
      logItem.Location = "POController";
      logItem.Layer = "IHM";

    }

    // Statuscode 500 = erreur serveur
    // les exceptions seront loggees
    [HttpGet]
    [Produces(typeof(List<ProductOwnerDTO>))]
    public ActionResult<List<ProductOwnerDTO>> get()
    {
      try
      {
        List<ProductOwnerDTO> retour = new List<ProductOwnerDTO>();
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

    [HttpGet("All")]
    [Produces(typeof(List<ProductOwnerDTO>))]
    public ActionResult<List<ProductOwnerDTO>> getAll()
    {
      try
      {
        List<ProductOwnerDTO> retour = new List<ProductOwnerDTO>();
        retour = _logic.List();
        return retour;
      }
      catch (Exception ex)
      {
        logItem.Exception = ex;
        logItem.MethodName = "GetAll";
        loggingService.WriteError(logItem);
        return StatusCode(500, ex);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<ProductOwnerDTO> GetById(int id)
    {
      try
      {
        ProductOwnerDTO retour = new ProductOwnerDTO();
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

    public ActionResult<ProductOwnerDTO> Post([FromBody] ProductOwnerDTO objet)
    {
      if (ModelState.IsValid)
      {
        try
        {
          ProductOwnerDTO resultat = _logic.Create(objet);
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
        return BadRequest("Invalid ProductOwnerDTO ModelState: failed to POST");
      }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    //modification d'entité avec fourniture de l'Id obligatoire
    public ActionResult<ProductOwnerDTO> Put([FromBody] ProductOwnerDTO objet)
    {
      if (ModelState.IsValid && objet.Id.HasValue)
      {
        try
        {
          ProductOwnerDTO resultat = _logic.Update(objet);
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
        return BadRequest("Invalid ProductOwnerDTO ModelState: failed to PUT");
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
        return BadRequest("Invalid ProductOwnerDTO ModelState: failed to DELETE");
      }
    }
  }
}

