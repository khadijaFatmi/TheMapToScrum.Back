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

        [HttpGet]
        [Produces(typeof(List<ProjectDTO>))]
        public List<ProjectDTO> get()
        {
            List<ProjectDTO> retour = new List<ProjectDTO>();
            retour = _logic.List();
            return retour;
        }

        [HttpGet("{id}")]
        public ProjectDTO GetById(int id)
        {
            ProjectDTO retour = new ProjectDTO();
            retour = _logic.GetById(id);
            return retour;
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
                return BadRequest("ProjectDTO invalide");
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
                return BadRequest("ProjectDTO invalide");
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
                return BadRequest("id invalide");
            }
        }
    }
}
