using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.Controllers
{
    //[Authorize]    
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        //injections dependances
        private readonly IProjectLogic _logic;

        public ProjectController(IProjectLogic logic)
        {
            _logic = logic;
        }

        // Statuscode 500 = erreur serveur
        // les exceptions seront loggees
        [HttpGet]
        [Produces(typeof(List<ProjectDTO>))]
        public ActionResult<List<ProjectDTO>> get()
        {
            try
            {
                List<ProjectDTO> retour = new List<ProjectDTO>();
                retour = _logic.ListActive();
                return retour;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("All")]
        [Produces(typeof(List<ProjectDTO>))]
        public ActionResult<List<ProjectDTO>> getAll()
        {
            try
            {
                List<ProjectDTO> retour = new List<ProjectDTO>();
                retour = _logic.List();
                return retour;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDTO> GetById(int id)
        {

            ProjectDTO retour = new ProjectDTO();
            try
            {                
                retour = _logic.GetById(id);
               
                if (retour.Id == null)
                {
                    return BadRequest("Invalid ProjectDTO ModelState: fail to GETbyId");
                }
                return retour;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ProjectDTO> Post([FromBody] ProjectDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProjectDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("Invalid ProjectDTO ModelState: fail to POST");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        //modification d'entité avec fourniture de l'Id obligatoire
        public ActionResult<ProjectDTO> Put([FromBody] ProjectDTO objet)
        {
            //PUT doit contenir  Id du projet et aussi etre valide
            if (ModelState.IsValid && objet.Id.HasValue)
            {
                try
                {
                    ProjectDTO resultat = _logic.Update(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("Invalid ProjectDTO ModelState: fail to PUT");
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
                    return null;
                }
            }
            else
            {
                return BadRequest("Invalid ProjectDTO Id: fail to DELETE");
            }
        }
    }
}
